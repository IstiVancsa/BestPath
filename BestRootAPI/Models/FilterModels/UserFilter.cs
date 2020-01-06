using Models.IFilterModels;
using System;
using System.Linq.Expressions;
using Utils;

namespace Models.FilterModels
{
    public class UserFilter : BaseFilterModel, IUserFilter
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Expression<Func<Entities.User, bool>> GetFilter()
        {
            Expression<Func<Entities.User, bool>> filter = x => true;

            if (this.Id.HasValue)
                filter = filter.And(x => x.Id == Id);
            if (!string.IsNullOrEmpty(this.Username))
                filter = filter.And(x => x.Username.Trim().ToLower().Contains(Username.Trim().ToLower()));
            if (!string.IsNullOrEmpty(this.Password))
                filter = filter.And(x => x.Password == Password);
            return filter;
        }
    }
}
