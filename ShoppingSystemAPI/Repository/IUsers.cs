using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystemAPI.Repository
{
    internal interface IUsers<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        User GetbyId(int id);
        void Post(TEntity user);
        void Put(int id, User user);
        void Delete(int id);
    }
}
 