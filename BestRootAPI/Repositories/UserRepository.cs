using Interfaces;

namespace Repositories
{
    public class UserRepository : GenericRepository<Entities.User>, IUserRepository
    {
        public UserRepository(BaseDataContext databaseContext) : base(databaseContext)
        {

        }
    }
}
