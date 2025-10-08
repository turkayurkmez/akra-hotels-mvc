using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniEShop.Application.Contracts
{
    public interface IRepository<T> where T : class
    {
        /*
         * SELECT * 
         * WHERE ID
         * INSERT
         * UPDATE
         * DELETE
         */

        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);


    }
}
