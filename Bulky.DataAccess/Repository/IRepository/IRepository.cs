using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    // we create the repositories to then reuse them in certain classes
    public interface IRepository<T> where T:class
    {
        //T Category
        IEnumerable<T> GetAll(string? includeProperties = null);  // here we created a function that retrieves all data 
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null); // and here for retrieving single data by its condition
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
