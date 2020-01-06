using Interfaces;

namespace Repositories
{
    public class CitiesRepository : GenericRepository<Entities.City>, ICityRepository
    {
        public CitiesRepository(BaseDataContext databaseContext) : base(databaseContext)
        {

        }
    }
}
