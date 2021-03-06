﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore
{
    public class Board
    {
        [Key]
        [JsonProperty("bid")]
        public int Id { get; set; }

        [JsonProperty("bsn")]
        public string BoardSN { get; set; }

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

        [JsonProperty("read")]
        public bool Read { get; set; }

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

        [JsonIgnore]
        public bool IsPopular { get; set; }

        [JsonProperty("moderators")]
        public virtual ICollection<User> Moderators { get; set; } = new HashSet<User>();

        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; } = new HashSet<Article>();
    }
}
