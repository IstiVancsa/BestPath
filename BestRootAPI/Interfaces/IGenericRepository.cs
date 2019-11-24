using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Models;
using Utils;

namespace Interfaces
{
    public interface IGenericRepository<TModel>
        where TModel : BaseModel, new()
    {

        void AddItem(TModel product);
        IQueryable<TModel> GetItems();

        IQueryable<TModel> GetItems(Expression<Func<TModel, bool>> predicate);

        TModel GetItem(Expression<Func<TModel, bool>> predicate);

        void UpdateItem(TModel myProduct);

        void DeleteItem(TModel myProduct);

        void DeleteItem(Guid id);

    }
}