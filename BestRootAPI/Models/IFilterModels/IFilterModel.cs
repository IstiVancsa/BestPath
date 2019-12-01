using System;
using System.Linq.Expressions;
using Entities;

namespace Models.IFilterModels
{
    public interface IFilterModel<TEntity>
        where TEntity : BaseEntity, new()
    {
        Expression<Func<TEntity, bool>> GetFilter();
    }
}
