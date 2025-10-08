using miniEShop.Application.Contracts;
using miniEShop.Entities;
using miniEShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniEShop.Infrastructure.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly MiniEShopDbContext dbContext;

        public EFCategoryRepository(MiniEShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Category entity)
        {
            dbContext.Categories.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category entity)
        {
            dbContext.Categories.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
