using ApplicationCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AspCoreOpenBBSMiddleware.DTO
{
    public class CommentListResult
    {
        [JsonProperty("list")]
        public List<Comment> List { get; set; }

        [JsonProperty("nextBID")]
        public string NextBoardID { get; set; }

        [JsonProperty("nextAID")]
        public string NextAutherID { get; set; }

        [JsonProperty("nextCID")]
        public string NextCID { get; set; }

        [JsonProperty("nextTime")]
        public int NextTime { get; set; }
    }
}
