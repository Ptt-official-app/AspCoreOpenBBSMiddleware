﻿using ApplicationCore;
using AspCoreOpenBBSMiddleware.Controllers.Base;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreOpenBBSMiddleware.Controllers
{
    public class CommentController : BaseController
    {
        private readonly CommentRepository _commentRepository;
        public CommentController(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        /// <summary>
        /// GetComments (取得所有公告)
        /// </summary>
        /// <param name="beforeTime">最晚發布時間</param>
        /// <param name="desc">由新至舊排序</param>
        /// <param name="limit">一次取回幾筆資料，最多1000</param>
        [HttpGet()]
        public ActionResult<IEnumerable<Comment>> GetAll([FromQuery] long beforeTime = -1,
                                                         [FromQuery] bool desc = true,
                                                         [FromQuery] int limit = 1000)
        {
            var result = from c in _commentRepository.Get()
                         where beforeTime != -1 || c.PostTime > beforeTime
                         select c;
            if (desc) result = result.OrderByDescending(c => c.PostTime);

            return Ok(result.Take(limit));
        }

        /// <summary>
        /// 取得特定公告
        /// </summary>
        /// <param name="id">唯一性編號</param>
        [HttpGet("{id}")]
        public Comment GetCommentById(int id)
        {
            var result = (from c in _commentRepository.Get()
                          where c.Id == id
                          select c)
                         .SingleOrDefault();
            return result;
        }

        /// <summary>
        /// 刪除特定
        /// </summary>
        /// <param name="id">唯一性編號</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteCommentById(int id)
        {
            Comment comment = (from c in _commentRepository.Get()
                               where c.Id == id
                               select c)
                              .SingleOrDefault();
            if(null != comment)
            {
                _commentRepository.Delete(comment);
                _commentRepository.Save();
            }
            return Ok();
        }
    }
}
