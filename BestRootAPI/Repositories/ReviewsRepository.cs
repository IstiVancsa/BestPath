using Interfaces;
using Models;

namespace Repositories
{
    public class ReviewsRepository : GenericRepository<ReviewDataContext,Review>, IReviewRepository
    {
    }
}
