using System;
using System.Linq.Expressions;
using Interfaces.IFilterModels;
using Utils;

namespace Models.FilterModels
{
    public class UserFilter : IUserFilter
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Expression<Func<User, bool>> GetFilter()
        {
            Expression<Func<User, bool>> filter = x => true;
            if (!string.IsNullOrEmpty(this.Username))
                filter = filter.And(x => x.Username.ToLower() == Username.ToLower());
            if (!string.IsNullOrEmpty(this.Password))
                filter = filter.And(x => x.Password == Password);
            return filter;
        }
    }
}
