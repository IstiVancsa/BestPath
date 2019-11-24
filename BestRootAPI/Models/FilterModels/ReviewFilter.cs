using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Interfaces.IFilterModels;
using Utils;

namespace Models.FilterModels
{
    public class ReviewFilter : IReviewFilter
    {
        public string ReviewComment { get; set; }
        public int Stars { get; set; }
        public Expression<Func<Review, bool>> GetFilter()
        {
            Expression<Func<Review, bool>> filter = x => true;

            if (string.IsNullOrEmpty(ReviewComment))
                filter = filter.And(x => x.ReviewComment == ReviewComment);

            if (string.IsNullOrEmpty(ReviewComment))
                filter = filter.And(x => x.Stars == Stars);

            return filter;
        }
    }
}
