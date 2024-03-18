using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category> 
    {
        // as you can see we created main interface of repositoryt and implemented here and then added more functionality 
        // then we will use it in our Category controller to obtain all these functions
        void Update(Category obj);
    }
}
