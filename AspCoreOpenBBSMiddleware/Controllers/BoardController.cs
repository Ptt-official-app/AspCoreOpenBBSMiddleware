﻿using ApplicationCore;
using AspCoreOpenBBSMiddleware.Controllers.Base;
using AspCoreOpenBBSMiddleware.DTO;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        /// GetBoardList (取得看板清單)
        /// </summary>
        /// <param name="isPopular">是否為熱門文章；預設為 否</param>
        /// <param name="title">部分看板標題</param>
        /// <param name="limit">一次取回幾筆資料，最多1000</param>
        [HttpGet()]
        public ActionResult<BoardListResult> GetAll([FromQuery] bool isPopular = false,
                                                    [FromQuery] string title = "",
                                                    [FromQuery] int limit = 1000)
        {
            var list = (from b in _boardRepository.Get()
                        where b.IsPopular == isPopular
                           && (string.IsNullOrWhiteSpace(title) || b.Title.Contains(title, StringComparison.CurrentCulture))
                        select b)
                       .Take(limit)
                       .ToDTO();
            if (!list.Any()) return NoContent();

            var next = _boardRepository.Get()
                                       .Skip(limit)
                                       .Take(1)
                                       .SingleOrDefault()
                                       .ToDTO();
            return new BoardListResult
            {
                List = list,
                Next = next
            };
        }

        /// <summary>
        /// 取得特定看板
        /// </summary>
        /// <param name="id">唯一性編號</param>
        [HttpGet("{id}")]
        public ActionResult<Board> GetBoardById(int id)
        {
            var boardList = (from b in _boardRepository.Get()
                             where b.Id == id
                             select b)
                            .SingleOrDefault();
            return Ok(boardList);
        }

        /// <summary>
        /// 刪除特定看板
        /// </summary>
        /// <param name="id">唯一性編號</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteBoardById(int id)
        {
            Board board = (from a in _boardRepository.Get()
                               where a.Id == id
                               select a)
                         .SingleOrDefault();
            if (null != board)
            {
                _boardRepository.Delete(board);
                _boardRepository.Save();
            }
            return Ok();
        }

        /// <summary>
        /// 取得特定看板下所有文章
        /// </summary>
        /// <param name="id">看板唯一性編號</param>
        /// <param name="aid">文章部分Id</param>
        [HttpGet("{id}/Articles")]
        public ActionResult<IEnumerable<Article>> GetArticlesByBoardId(int id,
                                                                       [FromQuery] string aid = "")
        {

            var articleList = from b in _boardRepository.Get()
                              where b.Id == id
                              select b.Articles.Where(
                                  a=> (string.IsNullOrWhiteSpace(aid) || a.Title.Contains(aid)));
            if (!articleList.Any()) return NoContent();
            return Ok(articleList);
        }

        /// <summary>
        /// 取得特定看板下特定文章
        /// </summary>
        /// <param name="bid">看板唯一性編號</param>
        /// <param name="aid">文章唯一性編號</param>
        [HttpGet("{bid}/Articles/{aid}")]
        public ActionResult<IEnumerable<Article>> GetArticleByBoardId(int bid, int aid)
        {
            var articleList = (from b in _boardRepository.Get()
                               where b.Id == bid
                               select b.Articles.Where(a=>a.Id == aid));
            if (!articleList.Any()) return NoContent();
            return Ok(articleList);
        }

        /// <summary>
        /// 取得特定看板下所有發文者
        /// </summary>
        /// <param name="bid">唯一性編號</param>
        /// <param name="uid">發文者部分Id</param>
        [HttpGet("{bid}/Users")]
        public ActionResult<IEnumerable<string>> GetUsersByBoardId(int bid,
                                                                   [FromQuery] string uid = "")
        {
            var authors = (from b in _boardRepository.Get()
                           where b.Id == bid
                           select b.Articles.Select(a => string.IsNullOrWhiteSpace(uid) || a.Author.Name.Contains(uid))
                          )
                          .Distinct();
            if (!authors.Any()) return NoContent();
            return Ok(authors);
        }

        /// <summary>
        /// 取得特定看板下特定發文者
        /// </summary>
        /// <param name="bid">看板唯一性編號</param>
        /// <param name="uid">使用者唯一性編號</param>
        [HttpGet("{bid}/Users/{uid}")]
        public ActionResult<IEnumerable<string>> GetUserByBoardId(int bid, int uid)
        {
            var author = (from b in _boardRepository.Get()
                          where b.Id == bid
                          select b.Articles
                                  .Where(a => a.Author.Id == uid)
                                  .Select(a => a.Author)
                         )
                         .SingleOrDefault();
            if (!author.Any()) return NoContent();
            return Ok(author);
        }
    }
}
