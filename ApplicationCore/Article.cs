using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore
{
    public class Article
    {
        [Key]
        [JsonProperty("aid")]
        public int Id { get; set; }

        #region Board
        [JsonProperty("bsn")]
        public string BoardSN { get; set; }

        [JsonProperty("bid")]
        public string BoardId { get; set; }

        [JsonIgnore]
        public virtual Board Board { get; set; }
        #endregion

        #region Author
        [JsonProperty("authorsn")]
        public string AuthorSN { get; set; }

        [JsonProperty("authorid")]
        public int AuthorId { get; set; }

        [JsonIgnore]
        public virtual User Author { get; set; }
        #endregion

        [JsonProperty("postTime")]
        public long PostTime { get; set; }

        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("read")]
        public bool Read { get; set; }

        [JsonProperty("flag")]
        public int Flag { get; set; }

        [JsonProperty("cat")]
        public string Category { get; set; }

        [JsonProperty("money")]
        public int Money { get; set; }

        [JsonProperty("nReader")]
        public int NumberOfReader { get; set; }

        [JsonProperty("nRecommend")]
        public int NumberOfRecommend { get; set; }

        [JsonIgnore]
        public bool IsPopular { get; set; }
    }
}
