using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystemAPI.Repository
{
    internal interface ICategory<TEntity>
    {
        IEnumerable<TEntity> GetAllCategorys();
        Category GetCategory(int id);
        void AddCategory(Category category);
        void UpdateCategory(int id, Category category);
        void DeleteCategory(int id);
    }
}
