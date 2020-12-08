using ApplicationCore;
using Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class BoardRepository : EFRepository<Board>
    {
        public BoardRepository(MWDBContext context) : base(context)
        {
            SetFakeData();
        }

        private void SetFakeData()
        {
#if !DEBUG
    return;
#endif
            if (GetAsNoTracking().Any()) return;

            var moderators = new List<Moderator>
            {
                new Moderator { Id = 1, UserSN = "sn-teemo", UserId = "teemo" },
                new Moderator { Id = 2, UserSN = "sn-okcool", UserId = "okcool" }
            };

            var newItem = new Board
            {
                Id = 1,
                BoardSN = "sn-PttNewhand",
                BoardId = "PttNewhand",
                Title = "批踢踢新手客服中心… 〃非test板",
                Flag = 1,
                Type = 2,
                Category = "新手",
                OnlineCount = 100,
                Moderators = moderators,
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
            };

            Insert(newItem);
            
            Save();
        }
    }
}
