using ApplicationCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreOpenBBSMiddleware.DTO
{
    public class BoardDTO
    {
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
        public virtual IEnumerable<Moderator> Moderators { get; set; }

        [JsonProperty("read")]
        public bool Read { get; set; }
    }

    public static class BoardDTOExtension
    {
        public static BoardDTO ToDTO(this Board source)
        {
            if (source == null) return null;

            return new BoardDTO
            {
                BoardId = source.BoardId,
                BoardSN = source.BoardSN,
                Title = source.Title,
                Category = source.Category,
                Flag = source.Flag,
                OnlineCount = source.OnlineCount,
                Read = source.Read,
                Type = source.Type,
                Moderators = source.Moderators
            };
        }

        public static IEnumerable<BoardDTO> ToDTO(this IEnumerable<Board> source)
        {
            return source.Select(b => b.ToDTO());
        }
    }
}
