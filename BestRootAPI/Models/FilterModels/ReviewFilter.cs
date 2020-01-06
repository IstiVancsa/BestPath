using Models.IFilterModels;
using System;
using System.Linq.Expressions;
using Utils;

namespace Models.FilterModels
{
    public class ReviewFilter : BaseFilterModel, IReviewFilter
    {
        public string ReviewComment { get; set; }
        public int? Stars { get; set; }
        public Expression<Func<Entities.Review, bool>> GetFilter()
        {
            Expression<Func<Entities.Review, bool>> filter = x => true;

            if (this.Id.HasValue)
                filter = filter.And(x => x.Id == Id);

            if (!string.IsNullOrEmpty(ReviewComment))
                filter = filter.And(x => x.ReviewComment.Trim().ToLower().Contains(ReviewComment.Trim().ToLower()));

            if (this.Stars.HasValue)
                filter = filter.And(x => x.Stars == Stars);

            return filter;
        }
    }
}
