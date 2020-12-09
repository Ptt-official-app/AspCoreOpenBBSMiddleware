using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("usn")]
        public string UserSN { get; set; }

        [JsonProperty("uid")]
        public string UserId { get; set; }

        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonProperty("realname")]
        public string RealName { get; set; }

        [JsonProperty("nLoginDays")]
        public int NumberOfLoginDays { get; set; }

        [JsonProperty("nPosts")]
        public int NumberOfPosts { get; set; }

        [JsonProperty("money")]
        public int Money { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("over18")]
        public bool Over18 { get; set; }

        [JsonProperty("firstLogin")]
        public long FirstLogin { get; set; }

        [JsonProperty("lastLogin")]
        public long LastLogin { get; set; }

        [JsonProperty("lastSeen")]
        public long LastSeen { get; set; }

        [JsonProperty("lastAct")]
        public long LastAct { get; set; }

        [JsonProperty("lastSong")]
        public long LastSong { get; set; }

        [JsonProperty("signature")]
        public int Signature { get; set; }

        [JsonProperty("vlcount")]
        public int Vlcount { get; set; }

        [JsonProperty("badpost")]
        public int Badpost { get; set; }

        [JsonProperty("timeRemoveBadPost")]
        public long TimeRemoveBadPost { get; set; }

        [JsonProperty("timeViolateLaw")]
        public long TimeViolateLaw { get; set; }

        [JsonProperty("myAngel")]
        public string MyAngel { get; set; }

        [JsonProperty("timeSetAngel")]
        public long TimeSetAngel { get; set; }

        [JsonProperty("timePlayAngel")]
        public long TimePlayAngel { get; set; }

        [JsonProperty("from")]
        public string FromCountry { get; set; }

        [JsonProperty("fromIp")]
        public string FromIP { get; set; }

        [JsonProperty("nFriends")]
        public int NumberOfFriends { get; set; }

        [JsonProperty("invisible")]
        public bool Invisible { get; set; }

        [JsonProperty("mode")]
        public int Mode { get; set; }

        [JsonProperty("alerts")]
        public int Alerts { get; set; }

        //[JsonProperty("dark")]
        //public List<int> Dark { get; set; }

        //[JsonProperty("conn6")]
        //public List<int> Conn6 { get; set; }

        //[JsonProperty("five")]
        //public List<int> Five { get; set; }

        //[JsonProperty("chc")]
        //public List<int> Chc { get; set; }

        //[JsonProperty("chess")]
        //public List<int> Chess { get; set; }

        //[JsonProperty("go")]
        //public List<int> Go { get; set; }

        [JsonIgnore]
        public virtual List<Board> Favorites { get; set; }
        [JsonIgnore]
        public virtual List<Comment> Comments { get; set; }
        [JsonIgnore]
        public virtual List<Artical> Articals { get; set; }

    }
}
