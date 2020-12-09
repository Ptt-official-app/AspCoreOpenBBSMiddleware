using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore
{
    /// <summary>
    /// 公告
    /// </summary>
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("bsn")]
        public string BoardSN { get; set; }

        [JsonProperty("bid")]
        public int BoardId { get; set; }

        [JsonProperty("asn")]
        public string AutherSN { get; set; }

        [JsonProperty("aid")]
        public int AutherId { get; set; }

        [JsonProperty("csn")]
        public string CommentSN { get; set; }

        [JsonProperty("cid")]
        public string CommentId { get; set; }

        [JsonProperty("postTime")]
        public long PostTime { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("comment")]
        public string Content { get; set; }

        [JsonProperty("flag")]
        public int Flag { get; set; }

        [JsonIgnore]
        public virtual User Author { get; set; }

        [JsonIgnore]
        public virtual Board BelongsBoard { get; set; }
    }
}
