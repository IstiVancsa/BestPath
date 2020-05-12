using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Interfaces
{
    public interface IBaseDataContext
    {
        DbSet<Review> Reviews { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<IdentityUser> IdentityUser { get; set; }
        DbSet<IdentityUserClaim<String>> IdentityUserClaims { get; set; }
    }
}
