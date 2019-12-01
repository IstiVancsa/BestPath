using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Models.IFilterModels;
using Utils;

namespace Models.FilterModels
{
    public class ReviewFilter : BaseFilterModel, IReviewFilter
    {
        public string ReviewComment { get; set; }
        public int Stars { get; set; }
        public Expression<Func<Entities.Review, bool>> GetFilter()
        {
            Expression<Func<Entities.Review, bool>> filter = x => true;

            if (this.Id.HasValue)
                filter = filter.And(x => x.Id == Id);

            if (string.IsNullOrEmpty(ReviewComment))
                filter = filter.And(x => x.ReviewComment == ReviewComment);

            if (string.IsNullOrEmpty(ReviewComment))
                filter = filter.And(x => x.Stars == Stars);

            return filter;
        }
    }
}
