using Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Interfaces
{
    public interface IBaseDataContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<City> Cities { get; set; }
    }
}
