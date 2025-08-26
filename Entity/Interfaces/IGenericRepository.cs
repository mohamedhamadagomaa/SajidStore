using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;

namespace Entity.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllMenus();
        IEnumerable<T> GetTypesOfItems();

        IList<T> GetAllVendors();

        T GetById(object? id);
        void Add(T entity);
        void Update(T entity );
        void Delete(object id);
    
    }
}
