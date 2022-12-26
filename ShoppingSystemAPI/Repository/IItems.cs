using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystemAPI.Repository
{
    internal interface IItems<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        Item Get(int id);
        void Add(Item item);
        void Update(int id, Item item);
        void Delete(int id);
    }
}
