using ApplicationCore.Helpers;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;
using System.Net;
using System.Text;

namespace AspCoreOpenBBSMiddleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                    .AddNewtonsoftJson();

            services.AddDbContext<MWDBContext>(options =>
#if !DEBUG
                        options.UseSqlServer(Configuration.GetConnectionString("Default"))
#else
                        options.UseInMemoryDatabase(databaseName: "InMemoryDb")
#endif
                        )
                    .AddScoped<ArticalRepository>()
                    .AddScoped<BoardRepository>()
                    .AddScoped<UserRepository>()
                    .AddScoped<CommentRepository>();

            AddSwaggerService(services);
            AddJwtService(services);
        }

        /// <summary>
        /// Register the Swagger services
        /// </summary>
        private void AddSwaggerService(IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Cool product name";
                    document.Info.Description = "with ASP.NET Core 3.1";
                };
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
                config.AddSecurity("JWT Token", Enumerable.Empty<string>(),
                            new OpenApiSecurityScheme()
                            {
                                Type = OpenApiSecuritySchemeType.ApiKey,
                                Name = nameof(Authorization),
                                In = OpenApiSecurityApiKeyLocation.Header,
                                Description = "Authorization header. Example: Bearer {token}"
                            }
                        );
            });
        }

        private void AddJwtService(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        // 當驗證失敗時，回應標頭會包含 WWW-Authenticate 標頭，這裡會顯示失敗的詳細錯誤原因
                        options.IncludeErrorDetails = false; // 預設值為 true，有時會特別關閉

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // 透過這項宣告，就可以從 "sub" 取值並設定給 User.Identity.Name
                            NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                            // 透過這項宣告，就可以從 "roles" 取值，並可讓 [Authorize] 判斷角色
                            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",

                            // 一般我們都會驗證 Issuer
                            ValidateIssuer = true,
                            ValidIssuer = Configuration.GetSection("JwtSettings:Issuer").Value,

                            // 通常不太需要驗證 Audience
                            ValidateAudience = false,
                            //ValidAudience = "JwtAuthDemo", // 不驗證就不需要填寫

                            // 一般我們都會驗證 Token 的有效期間
                            ValidateLifetime = true,

                            // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
                            ValidateIssuerSigningKey = false,

                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JwtSettings:SignKey").Value))
                        };
                    });
            services.AddSingleton<JWTProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    //先驗證
            app.UseAuthorization();     //再授權

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            RegisterSwagger(app);
        }

        private static void RegisterSwagger(IApplicationBuilder app)
        {
            app.UseOpenApi();   // Register the Swagger generator middleware
            app.UseSwaggerUi3(config => config.DocExpansion = "list");  // Register the Swagger UI middleware
            // Register the ReDoc UI
            app.UseReDoc(config =>
            {
                // 預設 ReDoc 路由為 /swagger，與 Swagger 相同，所以要錯開才能兩種都使用
                // 設定 ReDoc UI 的路由 (網址路徑) (一定要以 / 斜線開頭)
                config.Path = "/redoc";
            });
        }
    }
}
