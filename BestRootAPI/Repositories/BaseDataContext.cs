using Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Repositories
{
    public class BaseDataContext  : DbContext, IBaseDataContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<IdentityUser> IdentityUser { get; set; }
        public DbSet<IdentityUserClaim<String>> IdentityUserClaims { get; set; }

        public BaseDataContext(DbContextOptions<BaseDataContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
