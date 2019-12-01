using Interfaces;
using Models;

namespace Repositories
{
    public class ReviewsRepository : GenericRepository<Entities.Review>, IReviewRepository
    {
        public ReviewsRepository(BaseDataContext databaseContext) : base(databaseContext)
        {
            
        }
    }
}
