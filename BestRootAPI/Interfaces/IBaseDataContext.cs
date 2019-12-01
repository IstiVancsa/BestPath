using Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Interfaces
{
    public interface IBaseDataContext
    {
        DbContext DbContext { get; }

        DbSet<User> Users { get; set; }
        DbSet<Review> Reviews { get; set; }
    }
}
