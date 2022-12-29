using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystemAPI.Repository
{
    internal interface ICart<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        Cart Get(int id);
        void Add(Cart cart);
        void Update(int id, Cart cart);
        void Delete(int id);
    }
}
