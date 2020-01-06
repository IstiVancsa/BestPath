using System;
using System.Linq;
using System.Linq.Expressions;
using Entities;

namespace Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity, new()
    {

        void AddItem(TEntity product);
        IQueryable<TEntity> GetItems();

        IQueryable<TEntity> GetItems(Expression<Func<TEntity, bool>> predicate);

        TEntity GetItem(Expression<Func<TEntity, bool>> predicate);

        void UpdateItem(TEntity myProduct);

        void DeleteItem(TEntity myProduct);

        void DeleteItem(Guid id);

    }
}