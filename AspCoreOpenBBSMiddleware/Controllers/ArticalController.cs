using ApplicationCore;
using AspCoreOpenBBSMiddleware.Controllers.Base;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreOpenBBSMiddleware.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly ArticleRepository _articleRepository;
        public ArticleController(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        /// <summary>
        /// GetPost (取得所有文章)
        /// </summary>
        /// <param name="isPopular">是否為熱門文章；預設為 否</param>
        /// <param name="beforeTime">the newest-posttime in the list</param>
        /// <param name="startAID">starting article-id</param>
        /// <param name="ascending">升冪排序</param>
        /// <param name="max">max number of the returned posts, less or eqeal 1000</param>
        [HttpGet()]
        public ActionResult<IEnumerable<Article>> GetAll([FromQuery] bool isPopular = false,
                                                         [FromQuery] long beforeTime = -1,
                                                         [FromQuery] string startAID = "",
                                                         [FromQuery] bool ascending = true,
                                                         [FromQuery] int max = 1000)
        {
            var result = from a in _articleRepository.Get()
                         where (beforeTime != -1 || a.PostTime > beforeTime)
                            && a.IsPopular == isPopular
                            && (string.IsNullOrWhiteSpace(startAID) || a.ArticleId.StartsWith(startAID))
                         select a;
            if (ascending)
            {
                result = result.OrderBy(a => a.PostTime);
            }
            else
            {
                result = result.OrderByDescending(a => a.PostTime);
            }

            return Ok(result.Take(max));
        }

        [HttpGet("{id}")]
        public Article GetArticleById(int id)
        {
            var result = (from a in _articleRepository.Get()
                          where a.Id == id
                          select a)
                         .SingleOrDefault();
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticleById(int id)
        {
            Article article = (from a in _articleRepository.Get()
                               where a.Id == id
                               select a)
                              .SingleOrDefault();
            if(null != article)
            {
                _articleRepository.Delete(article);
                _articleRepository.Save();
            }
            return Ok();
        }
    }
}
