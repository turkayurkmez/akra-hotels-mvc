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


            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired()
                                                                 .HasMaxLength(250);
                                                                 



            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c=>c.Products)
                                          .HasForeignKey(p=>p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "Bilgisayar" },
                 new Category { Id = 2, Name = "Giyim" },
                 new Category { Id = 3, Name = "Kırtasiye" }
            );

            // Bilgisayar kategorisi ürünleri (CategoryId = 1)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop Dell XPS 13", Description = "13 inç ekranlı ultrabook", Price = 25000m, CategoryId = 1 },
                new Product { Id = 2, Name = "Gaming Mouse Logitech", Description = "RGB gaming mouse", Price = 850m, CategoryId = 1 },
                new Product { Id = 3, Name = "Mechanical Keyboard", Description = "Cherry MX anahtarlı klavye", Price = 1200m, CategoryId = 1 },
                new Product { Id = 4, Name = "Monitor 27 inch 4K", Description = "4K çözünürlüklü monitör", Price = 8500m, CategoryId = 1 },
                new Product { Id = 5, Name = "SSD Samsung 1TB", Description = "NVMe M.2 SSD", Price = 3200m, CategoryId = 1 },
                new Product { Id = 6, Name = "Webcam Logitech C920", Description = "Full HD webcam", Price = 1800m, CategoryId = 1 },
                new Product { Id = 7, Name = "USB Hub 7 Port", Description = "7 portlu USB hub", Price = 450m, CategoryId = 1 },
                new Product { Id = 8, Name = "Laptop Stand", Description = "Ayarlanabilir laptop standı", Price = 320m, CategoryId = 1 }
            );

            // Giyim kategorisi ürünleri (CategoryId = 2)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 9, Name = "T-Shirt Beyaz", Description = "Pamuklu beyaz t-shirt", Price = 180m, CategoryId = 2 },
                new Product { Id = 10, Name = "Jean Pantolon", Description = "Slim fit jean pantolon", Price = 450m, CategoryId = 2 },
                new Product { Id = 11, Name = "Kapüşonlu Sweatshirt", Description = "Unisex kapüşonlu sweatshirt", Price = 320m, CategoryId = 2 },
                new Product { Id = 12, Name = "Spor Ayakkabı", Description = "Koşu ayakkabısı", Price = 850m, CategoryId = 2 },
                new Product { Id = 13, Name = "Ceket Deri", Description = "Suni deri ceket", Price = 1200m, CategoryId = 2 },
                new Product { Id = 14, Name = "Elbise Yazlık", Description = "Çiçek desenli elbise", Price = 280m, CategoryId = 2 },
                new Product { Id = 15, Name = "Şapka Baseball", Description = "Ayarlanabilir şapka", Price = 120m, CategoryId = 2 },
                new Product { Id = 16, Name = "Çorap Spor 3'lü", Description = "Pamuklu spor çorap seti", Price = 85m, CategoryId = 2 }
            );

            // Kırtasiye kategorisi ürünleri (CategoryId = 3)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 17, Name = "Kalem Seti 12'li", Description = "Renkli kalem seti", Price = 45m, CategoryId = 3 },
                new Product { Id = 18, Name = "Defter A4 Kareli", Description = "100 sayfa kareli defter", Price = 25m, CategoryId = 3 },
                new Product { Id = 19, Name = "Silgi Beyaz", Description = "Beyaz silgi", Price = 8m, CategoryId = 3 },
                new Product { Id = 20, Name = "Cetvel 30cm", Description = "Plastik cetvel", Price = 12m, CategoryId = 3 },
                new Product { Id = 21, Name = "Kalemtıraş Metal", Description = "Metal kalemtıraş", Price = 15m, CategoryId = 3 },
                new Product { Id = 22, Name = "Yapıştırıcı Stick", Description = "21g yapıştırıcı stick", Price = 18m, CategoryId = 3 },
                new Product { Id = 23, Name = "Dosya Plastik", Description = "A4 plastik dosya", Price = 35m, CategoryId = 3 },
                new Product { Id = 24, Name = "Post-it Notlar", Description = "Renkli yapışkanlı notlar", Price = 22m, CategoryId = 3 }
            );
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
