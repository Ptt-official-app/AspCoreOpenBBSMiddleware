using ApplicationCore;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
    public class UserRepository : EFRepository<User>
    {
        public UserRepository(MWDBContext context) : base(context)
        {
        }
    }
}
