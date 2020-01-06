using Entities;
using System;
using System.Linq.Expressions;

namespace Models.IFilterModels
{
    public interface IFilterModel<TEntity>
        where TEntity : BaseEntity, new()
    {
        Expression<Func<TEntity, bool>> GetFilter();
    }
}
