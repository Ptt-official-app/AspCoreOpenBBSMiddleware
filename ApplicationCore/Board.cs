using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("bsn")]
        public string BoardSN { get; set; }

        [JsonProperty("bid")]
        public string BoardId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("flag")]
        public int Flag { get; set; }

        [JsonProperty("boardType")]
        public int Type { get; set; }

        [JsonProperty("cat")]
        public string Category { get; set; }

        [JsonProperty("onlineCount")]
        public int OnlineCount { get; set; }

        [JsonProperty("moderators")]
        public virtual List<Moderator> Moderators { get; set; }

        [JsonProperty("read")]
        public bool Read { get; set; }

        //------------------
        [JsonProperty("voteLimitLogins")]
        public int VoteLimitLogins { get; set; }

        [JsonProperty("bUpdate")]
        public long BoardUpdate { get; set; }

        [JsonProperty("postLimitLogins")]
        public int PostLimitLogins { get; set; }

        [JsonProperty("vote")]
        public int Vote { get; set; }

        [JsonProperty("vtime")]
        public long VoteTime { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("lastSetTime")]
        public long LastSetTime { get; set; }

        [JsonProperty("postExpire")]
        public long PostExpire { get; set; }

        [JsonProperty("EndGamble")]
        public long EndGamble { get; set; }

        [JsonProperty("postType")]
        public string PostType { get; set; }

        [JsonProperty("fastRecommendPause")]
        public int FastRecommendPause { get; set; }

        [JsonProperty("voteLimitBadpost")]
        public int VoteLimitBadpost { get; set; }

        [JsonProperty("postLimitBadpost")]
        public int PostLimitBadpost { get; set; }
    }

    public class Moderator
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("usn")]
        public string UserSN { get; set; }

        [JsonProperty("uid")]
        public string UserId { get; set; }
    }
}
