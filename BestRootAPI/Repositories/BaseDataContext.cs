using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
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
        public BaseDataContext(DbContextOptions<BaseDataContext> options): base(options)
        {
            Database.Migrate();
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .Property(t => t.Id)
        //        .IsRequired()
        //        .HasMaxLength(40);

        //    Entities.User user = new Entities.User();
        //    // Kind of Seed Method
        //    modelBuilder.Entity<User>().HasData(
        //        user.CreateSeeds(10));


        //    modelBuilder.Entity<Review>()
        //        .Property(t => t.Id)
        //        .IsRequired()
        //        .HasMaxLength(40);

        //    Entities.Review review = new Entities.Review();
        //    // Kind of Seed Method
        //    modelBuilder.Entity<Review>().HasData(
        //        review.CreateSeeds(10));
        //}
    }
}
