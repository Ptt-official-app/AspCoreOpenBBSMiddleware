using ApplicationCore;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
    public class ArticleRepository : EFRepository<Article>
    {
        public ArticleRepository(MWDBContext context) : base(context)
        {
        }
    }
}
