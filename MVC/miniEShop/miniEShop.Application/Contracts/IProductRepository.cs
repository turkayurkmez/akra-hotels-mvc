using miniEShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniEShop.Application.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {

        IEnumerable<Product> SearchByName(string name);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        IEnumerable<Product> GetWithPagination(int page, int pageSize);
    }
}
