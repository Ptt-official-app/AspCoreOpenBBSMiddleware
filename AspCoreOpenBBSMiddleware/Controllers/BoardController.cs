using ApplicationCore;
using AspCoreOpenBBSMiddleware.Controllers.Base;
using AspCoreOpenBBSMiddleware.DTO;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AspCoreOpenBBSMiddleware.Controllers
{
    public class BoardController : BaseController
    {
        private readonly BoardRepository _boardRepository;

        public BoardController(BoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        /// <summary>
        /// GetPopularBoardList (取得熱門看板清單)
        /// </summary>
        ///<param name="startBID">starting board-id</param>
        ///<param name="max">max number of the returned boards</param>
        [HttpGet("Populars")]
        public ActionResult<BoardListResult> GetPopularList([FromQuery] string startBID = "", [FromQuery] int max = 1000)
        {
            var list = (from b in _boardRepository.Get()
                        where string.IsNullOrWhiteSpace(startBID) || b.BoardId.StartsWith(startBID, StringComparison.CurrentCultureIgnoreCase)
                        select b)
                       .Take(max)
                       .ToDTO();
            if (!list.Any()) return NoContent();

            var next = _boardRepository.Get()
                                       .Skip(max)
                                       .Take(1)
                                       .SingleOrDefault()
                                       .ToDTO();
            return new BoardListResult
            {
                List = list.AsEnumerable(),
                Next = next
            };
        }

        /// <summary>
        /// GetBoardList (取得看板清單)
        /// </summary>
        /// <param name="bid">sub-string of the board-name (bid)</param>
        /// <param name="title">sub-string of the board-title</param>
        /// <param name="max">max number of the returned boards</param>
        [HttpGet()]
        public ActionResult<BoardDTO> GetBoard([FromQuery] string bid = "", [FromQuery] string title = "", [FromQuery] int max = 1000)
        {
            var result = (from b in _boardRepository.Get()
                          where (string.IsNullOrWhiteSpace(bid) || b.BoardId.Contains(bid, StringComparison.CurrentCultureIgnoreCase))
                             && (string.IsNullOrWhiteSpace(title) || b.Title.Contains(title, StringComparison.CurrentCulture))
                          select b)
                         .Take(max)
                         .ToDTO();
            return Ok(result);
        }

        /// <summary>
        /// GetBoardDetail (取得看板詳細資訊)
        /// </summary>
        /// <param name="bid"></param>
        [HttpGet("Detail/{bid}")]
        public ActionResult<Board> GetBoardDetail(string bid)
        {
            var boardList = from b in _boardRepository.Get()
                            where b.BoardId == bid
                            select b;
            return Ok(boardList);
        }
    }
}
