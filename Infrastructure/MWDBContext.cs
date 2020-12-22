using ApplicationCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MWDBContext : DbContext
    {
        public MWDBContext()
        { }

        public MWDBContext(DbContextOptions<MWDBContext> options) : base(options)
        { }

        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Board>(entity =>
            //{
            //    entity.HasKey(b => b.Id);

            //    entity.Property(b => b.BoardId)
            //        .IsRequired()
            //        .HasMaxLength(30);

            //    entity.Property(e => e.BoardSN).HasMaxLength(50);
            //});

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.HasKey(u => u.Id);

            //    entity.Property(u => u.UserId)
            //        .IsRequired()
            //        .HasMaxLength(30);

            //    entity.Property(e => e.UserSN).HasMaxLength(50);
            //});

            //modelBuilder.Entity<Article>(entity =>
            //{
            //    entity.HasKey(a => a.Id);

            //    entity.Property(a => a.ArticleId)
            //        .IsRequired()
            //        .HasMaxLength(30);
            //});
        }
    }
}
