using Newtonsoft.Json;
using System.Collections.Generic;

namespace AspCoreOpenBBSMiddleware.DTO
{
    public class BoardListResult
    {
        [JsonProperty("list")]
        public IEnumerable<BoardDTO> List { get; set; }

        [JsonProperty("nextBID")]
        public virtual string NextBoardID => null == Next ? "" : Next.BoardId;

        [JsonIgnore]
        public BoardDTO Next { get; set; }
    }
}
