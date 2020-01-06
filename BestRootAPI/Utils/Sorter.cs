using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Utils
{
    public abstract class Sorter<TModel>
     where TModel : BaseModel
    {
        public abstract IQueryable<TModel> Sort(IQueryable<TModel> queryable, bool isThenBy);
        public abstract IEnumerable<TModel> SortList(IEnumerable<TModel> enumerable, bool isThenBy);

        public static Sorter<TModel> Get<TOrderKey>(Expression<Func<TModel, TOrderKey>> orderBy, bool ascending)
            => new TypedSorter<TOrderKey>(orderBy, ascending);

        class TypedSorter<TOrderKey> : Sorter<TModel>
        {
            Expression<Func<TModel, TOrderKey>> OrderBy;
            bool Ascending;
            public TypedSorter(Expression<Func<TModel, TOrderKey>> orderBy, bool ascending)
            {
                OrderBy = orderBy;
                Ascending = ascending;
            }

            public override IQueryable<TModel> Sort(IQueryable<TModel> queryable, bool isThenBy)
                => isThenBy ?
            (
                Ascending ?
                (queryable as IOrderedQueryable<TModel>).ThenBy(OrderBy) :
                (queryable as IOrderedQueryable<TModel>).ThenByDescending(OrderBy)
            ) :
            (
                Ascending ?
                queryable.OrderBy(OrderBy) :
                queryable.OrderByDescending(OrderBy)
            );



            public override IEnumerable<TModel> SortList(IEnumerable<TModel> enumerable, bool isThenBy)
            => isThenBy ?
        (
            Ascending ?
            (enumerable as IOrderedEnumerable<TModel>).ThenBy(OrderBy.Compile()) :
            (enumerable as IOrderedEnumerable<TModel>).ThenByDescending(OrderBy.Compile())
        ) :
        (
            Ascending ?
            enumerable.OrderBy(OrderBy.Compile()) :
            enumerable.OrderByDescending(OrderBy.Compile())
        );
        }
    }
}
