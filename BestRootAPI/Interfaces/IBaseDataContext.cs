using Entities;
using Microsoft.EntityFrameworkCore;

namespace Interfaces
{
    public interface IBaseDataContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<City> Cities { get; set; }
    }
}
