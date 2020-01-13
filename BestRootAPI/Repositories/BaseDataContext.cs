using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Repositories
{
    public class BaseDataContext : DbContext, IBaseDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<City> Cities { get; set; }
        public BaseDataContext(DbContextOptions<BaseDataContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
