using ApplicationCore;
using AspCoreOpenBBSMiddleware.Controllers.Base;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreOpenBBSMiddleware.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// GetUser(取得所有使用者)
        /// </summary>
        /// <param name="userID">starting user-id</param>
        /// <param name="ascending">LastLogin 升冪排序</param>
        /// <param name="max">max number of the returned user, less or eqeal 1000</param>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<IEnumerable<User>> GetAll([FromQuery] string userID = "",
                                                      [FromQuery] bool ascending = true,
                                                      [FromQuery] int max = 1000)
        {
            var result = from u in _userRepository.Get()
                         where (string.IsNullOrWhiteSpace(userID) || u.UserId.Contains(userID))
                         select u;
            if (ascending)
            {
                result = result.OrderBy(u => u.LastLogin);
            }
            else
            {
                result = result.OrderByDescending(a => a.LastLogin);
            }

            return Ok(result.Take(max));
        }

        /// <summary>
        /// 取得特定使用者
        /// </summary>
        /// <param name="uid">唯一性編號</param>
        [HttpGet("{uid}")]
        public ActionResult<IEnumerable<User>> GetUser(int uid)
        {
            var result = from u in _userRepository.Get()
                         where u.Id == uid
                         select u;
            return Ok(result);
        }

        /// <summary>
        /// 刪除特定使用者
        /// </summary>
        /// <param name="uid">唯一性編號</param>
        [HttpDelete("{uid}")]
        public IActionResult DeleteBoardById(int uid)
        {
            User user = (from a in _userRepository.Get()
                         where a.Id == uid
                         select a)
                        .SingleOrDefault();
            if (null != user)
            {
                _userRepository.Delete(user);
                _userRepository.Save();
            }
            return Ok();
        }

        /// <summary>
        /// 取得特定使用者公告
        /// </summary>
        /// <param name="uid">唯一性編號</param>
        [HttpGet("{uid}/Comments")]
        public ActionResult<IEnumerable<User>> GetUserComments(int uid)
        {
            var result = from u in _userRepository.Get()
                         where u.Id == uid
                         select null == u ? null : u.Comments;
            return Ok(result);
        }

        /// <summary>
        /// 取得特定使用者最愛
        /// </summary>
        /// <param name="uid">唯一性編號</param>
        [HttpGet("{uid}/Favorites")]
        public ActionResult<IEnumerable<Board>> GetUserFavorites(int uid)
        {
            var result = from u in _userRepository.Get()
                         where u.Id == uid
                         select null == u ? null : u.Favorites;
            return Ok(result);
        }

        /// <summary>
        /// 取得特定使用者文章
        /// </summary>
        /// <param name="uid">唯一性編號</param>
        [HttpGet("{uid}/Articles")]
        public ActionResult<IEnumerable<Article>> GetUserArticles(int uid)
        {
            var result = from u in _userRepository.Get()
                         where u.Id == uid 
                         select null == u ? null : u.Articles;
            return Ok(result);
        }
    }
}
