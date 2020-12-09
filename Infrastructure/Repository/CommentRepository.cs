using ApplicationCore;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
    public class CommentRepository : EFRepository<Comment>
    {
        public CommentRepository(MWDBContext context) : base(context)
        {
        }
    }
}
