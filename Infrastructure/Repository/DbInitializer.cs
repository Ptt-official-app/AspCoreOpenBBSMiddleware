using ApplicationCore;
using System.Collections.Generic;

namespace Infrastructure.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(MWDBContext context)
        {
            context.Database.EnsureCreated();

            #region User
            User user_teemo = new User
            {
                Id = 1,
                UserSN = "sn-teemo",
                UserId = "teemo",
                NickName = "提摩",
                RealName = "真 . 提摩",
                NumberOfLoginDays = 1,
                NumberOfPosts = 1000,
                Money = 0,
                Email = "teemo@ptt.cc",
                Address = "台北市天龍區天龍路87號",
                Over18 = true,
                FirstLogin = 1234567890,
                LastLogin = 1234567890,
                LastSeen = 1234567890,
                LastAct = 1234567890,
                LastSong = 1234567890,
                Signature = 0,
                Vlcount = 0,
                Badpost = 0,
                TimeRemoveBadPost = 1234567890,
                TimeViolateLaw = 1234567890,
                MyAngel = "馬鸚酒",
                TimeSetAngel = 1234567890,
                TimePlayAngel = 1234567890,
                FromCountry = "台灣",
                FromIP = "127.0.0.1",
                NumberOfFriends = 0,
                Invisible = false,
                Mode = 1,
                Alerts = 0,
            };
            User user_okcool = new User
            {
                Id = 2,
                UserSN = "sn-okcool",
                UserId = "okcool",
                NickName = "okcool",
                RealName = "真 . okcool",
                NumberOfLoginDays = 1,
                NumberOfPosts = 1000,
                Money = 0,
                Email = "teemo@ptt.cc",
                Address = "台北市天龍區天龍路87號",
                Over18 = true,
                FirstLogin = 1234567890,
                LastLogin = 1234567890,
                LastSeen = 1234567890,
                LastAct = 1234567890,
                LastSong = 1234567890,
                Signature = 0,
                Vlcount = 0,
                Badpost = 0,
                TimeRemoveBadPost = 1234567890,
                TimeViolateLaw = 1234567890,
                MyAngel = "馬鸚酒",
                TimeSetAngel = 1234567890,
                TimePlayAngel = 1234567890,
                FromCountry = "台灣",
                FromIP = "127.0.0.1",
                NumberOfFriends = 0,
                Invisible = false,
                Mode = 1,
                Alerts = 0,
            };
            context.Users.Add(user_teemo);
            context.SaveChanges();
            #endregion
            #region Article
            Article article1 = new Article
            {
                Id = 1,
                BoardSN = "sn-undefined",
                BoardId = "undefined",
                ArticleId = "aid0",
                AuthorSN = user_teemo.UserSN,
                AuthorId = user_teemo.Id,
                Author = user_teemo,
                PostTime = 1234567891,
                UpdateTime = 1234567891,
                Date = "2009-02-14",
                Title = "我在哪裡？",
                Href = "/Article/undefined/aid0",
                Read = false,
                Flag = 0,
                Category = "問題",
                Money = 1,
                NumberOfReader = 1,
                NumberOfRecommend = -1000
            };
            Article article2 = new Article
            {
                Id = 2,
                BoardSN = "sn-undefined???",
                BoardId = "undefined???",
                ArticleId = "aid2",
                AuthorSN = user_teemo.UserSN,
                AuthorId = user_teemo.Id,
                Author = user_teemo,
                PostTime = 1234567891,
                UpdateTime = 1234567891,
                Date = "2009-02-14",
                Title = "我在哪裡？",
                Href = "/Article/undefined/aid1",
                Read = false,
                Flag = 0,
                Category = "問題",
                Money = 1,
                NumberOfReader = 1,
                NumberOfRecommend = -1000,
                IsPopular = true
            };
            context.Articles.Add(article1);
            context.Articles.Add(article2);
            context.SaveChanges();
            #endregion
            #region Board
            var board = new Board
            {
                Id = 1,
                BoardSN = "sn-PttNewhand",
                BoardId = "PttNewhand",
                Title = "批踢踢新手客服中心… 〃非test板",
                Flag = 1,
                Type = 2,
                Category = "新手",
                OnlineCount = 100,
                Moderators = new List<User>() { user_teemo, user_okcool },
                Read = false,
                VoteLimitLogins = 10,
                BoardUpdate = 1234567890,
                PostLimitLogins = 10,
                Vote = 3,
                VoteTime = 1234567890,
                Level = 123,
                LastSetTime = 1234567890,
                PostExpire = 120,
                EndGamble = 1234567890,
                PostType = "post-type",
                FastRecommendPause = 60,
                VoteLimitBadpost = 15,
                PostLimitBadpost = 13,
                Articles = new List<Article>() { article1, article2},
                IsPopular = true
            };
            context.Boards.Add(board);
            context.SaveChanges();
            #endregion            
            #region Comment
            var cmt1 = new Comment
            {
                Id = 1,
                BelongsBoard = board,
                BoardSN = board.BoardSN,
                BoardId = board.Id,
                Author = user_teemo,
                AutherSN = user_teemo.UserSN,
                AutherId = user_teemo.Id,
                CommentSN = "sn-cid3",
                CommentId = "cid3",
                PostTime = 1234567891,
                Title = "[公告] 你誰啊, 亂公告",
                Content = "我是站長",
                Flag = 0,
            };
            context.Comments.Add(cmt1);
            var cmt2 = new Comment
            {
                Id = 2,
                BelongsBoard = board,
                BoardSN = board.BoardSN,
                BoardId = board.Id,
                Author = user_teemo,
                AutherSN = user_teemo.UserSN,
                AutherId = user_teemo.Id,
                CommentSN = "sn-cid3",
                CommentId = "cid3",
                PostTime = 1234567891,
                Title = "[公告] 測試公告",
                Content = "我是路人",
                Flag = 0,
            };
            context.Comments.Add(cmt2);
            context.SaveChanges();
            #endregion

            user_teemo.Articles = new List<Article>() { article1, article2 };
            user_teemo.Favorites = new List<Board>() { board };
            user_teemo.Comments = new List<Comment>() { cmt1, cmt2 };
        }
    }
}
