using Microsoft.EntityFrameworkCore;
using miniEShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniEShop.Infrastructure.Data
{
    public class MiniEShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MiniEShopDbContext(DbContextOptions<MiniEShopDbContext> option):base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired()
                                                                .HasMaxLength(150);


            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c=>c.Products)
                                          .HasForeignKey(p=>p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=AkraHotels_EgitimDb;Integrated Security=True;Encrypt=True");

        //    /*
        //     * Data Source=localhost,1433;Initial Catalog=AkraHotelsDb;User ID=sa; pwd=Password; Encrypt=False;Trust Server Certificate=True
        //     */
        //}
    }

}
