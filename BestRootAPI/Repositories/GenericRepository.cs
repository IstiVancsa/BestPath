using System;
using System.Linq;
using System.Linq.Expressions;
using Interfaces;
using Models;

namespace Repositories
{
    public class GenericRepository<TContext, TModel> : IGenericRepository<TModel>
         where TModel : BaseModel, new()
         where TContext : BaseDataContext<TModel>, new()
    { 
        public void AddItem(TModel item)
        {
            using (var ctx = new TContext())
            {
                ctx.Items.Add(item);
                ctx.SaveChanges();
            }
        }

        public IQueryable<TModel> GetItems()
        {
            IQueryable<TModel> items;

            using (var ctx = new TContext())
            {
                items = ctx.Items.Where(s => true)
                                        .OrderBy(x => x.Id);
            }

            return items;
        }

        public IQueryable<TModel> GetItems(Expression<Func<TModel, bool>> predicate)
        {
            IQueryable<TModel> items;

            using (var ctx = new TContext())
            {
                items = ctx.Items.Where(predicate)
                    .OrderBy(x => x.Id);
            }

            return items;
        }

        public TModel GetItem(Expression<Func<TModel, bool>> predicate)
        {
            TModel myItems;

            using (var ctx = new TContext())
            {
                myItems = ctx.Items.Where(predicate)
                    .FirstOrDefault();
            }

            return myItems;
        }

        public void UpdateItem(TModel myProduct)
        {
            using (var ctx = new TContext())
            {
                ctx.Update(myProduct);
                ctx.SaveChanges();
            }
        }

        public void DeleteItem(TModel myProduct)
        {
            using (var ctx = new TContext())
            {
                ctx.Remove(myProduct);
                ctx.SaveChanges();
            }
        }

        public void DeleteItem(Guid id)
        {
            using (var ctx = new TContext())
            {
                ctx.Remove(ctx.Items.Where(x => x.Id == id));
                ctx.SaveChanges();
            }
        }

    }
}

