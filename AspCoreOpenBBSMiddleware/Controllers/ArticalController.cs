using ApplicationCore;
using AspCoreOpenBBSMiddleware.Controllers.Base;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreOpenBBSMiddleware.Controllers
{
    public class ArticalController : BaseController
    {
        private readonly ArticalRepository _articalRepository;
        public ArticalController(ArticalRepository articalRepository)
        {
            _articalRepository = articalRepository;
        }

        /// <summary>
        /// GetPost (取得所有文章)
        /// </summary>
        /// <param name="isPopular">是否為熱門文章；預設為 否</param>
        /// <param name="beforeTime">最晚發布時間</param>
        /// <param name="title">部分文章標題</param>
        /// <param name="desc">由新至舊排序</param>
        /// <param name="max">一次取回幾筆資料，最多1000</param>
        [HttpGet()]
        public ActionResult<IEnumerable<Artical>> GetAll([FromQuery] bool isPopular = false,
                                                         [FromQuery] long beforeTime = -1,
                                                         [FromQuery] string title = "",
                                                         [FromQuery] bool desc = true,
                                                         [FromQuery] int max = 1000)
        {
            var result = from a in _articalRepository.Get()
                         where (beforeTime != -1 || a.PostTime > beforeTime)
                            && a.IsPopular == isPopular
                            && (string.IsNullOrWhiteSpace(title) || a.Title.Contains(title))
                         select a;
            if (desc) result = result.OrderByDescending(a => a.PostTime);

            return Ok(result.Take(max));
        }

        [HttpGet("{id}")]
        public Artical GetArticalById(int id)
        {
            var result = (from a in _articalRepository.Get()
                          where a.Id == id
                          select a)
                         .SingleOrDefault();
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticalById(int id)
        {
            Artical artical = (from a in _articalRepository.Get()
                               where a.Id == id
                               select a)
                              .SingleOrDefault();
            if(null != artical)
            {
                _articalRepository.Delete(artical);
                _articalRepository.Save();
            }
            return Ok();
        }
    }
}
