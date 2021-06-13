using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clothing_Api.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Clothing_Api.Data
{
    public class ClothingDbContext : IdentityDbContext
    {
        public ClothingDbContext(DbContextOptions<ClothingDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductEntity>().ToTable("Products");
            modelBuilder.Entity<ProductEntity>().Property(a => a.Id).ValueGeneratedOnAdd();
        }


        public DbSet<ProductEntity> Products { get; set; }
    }
}
