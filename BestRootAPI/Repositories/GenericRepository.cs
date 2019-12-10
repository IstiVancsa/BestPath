using System;
using System.Linq;
using System.Linq.Expressions;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
         where TEntity : BaseEntity, new()
    {
        private BaseDataContext DatabaseContext { get; set; }

        public GenericRepository(BaseDataContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }
        public void AddItem(TEntity item)
        {
            DatabaseContext.Set<TEntity>().Add(item);
            SaveChanges();
        }

        public IQueryable<TEntity> GetItems()
        {
            IQueryable<TEntity> items = DatabaseContext.Set<TEntity>().Include(DatabaseContext.GetIncludePaths(typeof(TEntity))).Where(x => true)
                .OrderBy(x => x.Id);

            return items;
        }

        public IQueryable<TEntity> GetItems(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> items = DatabaseContext.Set<TEntity>().Include(DatabaseContext.GetIncludePaths(typeof(TEntity))).Where(predicate)
                .OrderBy(x => x.Id);

            return items;
        }

        public TEntity GetItem(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity myItem = DatabaseContext.Set<TEntity>().Include(DatabaseContext.GetIncludePaths(typeof(TEntity))).Where(predicate)
                .FirstOrDefault();


            return myItem;
        }

        public void UpdateItem(TEntity myProduct)
        {
            DatabaseContext.Set<TEntity>().Update(myProduct);
            SaveChanges();
        }

        public void DeleteItem(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public void DeleteItem(Guid id)
        {
            TEntity myEntity = DatabaseContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            if (myEntity != null)
                DatabaseContext.Set<TEntity>().Remove(myEntity);
            SaveChanges();
        }

        public int SaveChanges() { return DatabaseContext.SaveChanges(); }

    }
}

