using Entities;
using Models.IFilterModels;
using System;
using System.Linq.Expressions;

namespace Models.FilterModels
{
    public class BaseFilterModel<TEntity> : IFilterModel<TEntity>
        where TEntity : BaseEntity, new()
    {
        public Guid? Id { get; set; }

        public Expression<Func<TEntity, bool>> GetFilter()
        {
            throw new NotImplementedException();
        }
    }
}
