using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniEShop.Application.Contracts;
using miniEShop.Entities;
using miniEShop.Infrastructure.Data;

namespace miniEShop.Infrastructure.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly MiniEShopDbContext dbContext;

        public EFProductRepository(MiniEShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(Product entity)
        {
            dbContext.Products.Add(entity);
            dbContext.SaveChanges();

            //Product product = dbContext.Products.FirstOrDefault(p => p.Id == 1);
            //product.Price += 100;
            //Persistence API Pattern
        }

        public void Delete(int id)
        {
            var product = dbContext.Products.SingleOrDefault(p => p.Id == id);
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return dbContext.Products.Where(p => p.CategoryId == categoryId)
                                     .ToList();
        }

        public IEnumerable<Product> GetWithPagination(int page, int pageSize)
        {
           return dbContext.Products.OrderBy(p=>p.Id).Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            return dbContext.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()))
                                     .ToList();
        }

        public void Update(Product entity)
        {
            dbContext.Products.Update(entity);
            dbContext.SaveChanges();
        }
    }


}
