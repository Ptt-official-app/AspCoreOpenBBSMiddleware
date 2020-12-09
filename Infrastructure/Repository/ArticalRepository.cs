using ApplicationCore;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
    public class ArticalRepository : EFRepository<Artical>
    {
        public ArticalRepository(MWDBContext context) : base(context)
        {
        }
    }
}
