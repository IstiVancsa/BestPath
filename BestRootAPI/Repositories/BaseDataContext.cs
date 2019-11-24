using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Repositories
{
    public class BaseDataContext<TModel> : DbContext, IBaseDataContext<TModel>
        where TModel : BaseModel, new()
    {

        public IDbSet<TModel> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                // optionsBuilder.UseInMemoryDatabase("MyDatabase");

                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Town;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TModel>()
                .Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(40);

            TModel myModel = new TModel();
            // Kind of Seed Method
            modelBuilder.Entity<TModel>().HasData(
                myModel.CreateSeeds(10));
        }
    }
}
