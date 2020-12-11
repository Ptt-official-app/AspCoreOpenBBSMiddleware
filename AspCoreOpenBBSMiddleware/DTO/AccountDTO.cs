using Newtonsoft.Json;

namespace AspCoreOpenBBSMiddleware.DTO
{
    public class AccountDTO
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string PassWord { get; set; }
        [JsonProperty("password_confirm")]
        public string PasswordConfirm { get; set; }
        [JsonProperty("over18")]
        public bool Over18 { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("nickname")]
        public string NickName { get; set; }
        [JsonProperty("realname")]
        public string RealName { get; set; }
        [JsonProperty("career")]
        public string Career { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
