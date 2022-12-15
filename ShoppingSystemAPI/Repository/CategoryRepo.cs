using Microsoft.AspNet.Identity;
using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystemAPI.Repository
{
    public class CategoryRepo : ICategory<Category>
    {
        Entities _CategoryEntities;

        //Constructor Dependancy injection
        Entities _userdbcontext;
        public CategoryRepo(Entities context)
        {
            _CategoryEntities = context;
        }
        //For Add new Category
        #region To Add new Category
        public void AddCategory(Category newCategory)
        {
            _CategoryEntities.Categories.Add(newCategory);
           _CategoryEntities.SaveChanges();
        }
        #endregion

        //method to delete Category
        #region To Delete Category
        public void DeleteCategory(int id)
        {
            Category Ut = _CategoryEntities.Categories.Find(id);
           _CategoryEntities.Categories.Remove(Ut);
            _CategoryEntities.SaveChanges();

        }
        #endregion

        //To Display all Categorys
        #region To Display all Categories
        public IEnumerable<Category> GetAllCategorys()
        {

            return _CategoryEntities.Categories.ToList();

        }
        #endregion

        //To Display Category by ID
        #region Get Category Details By ID
        public Category GetCategory(int id)
        {
            return _CategoryEntities.Categories.Find(id);

        }
        #endregion

        //To Update Category
        #region UPDATE Category
        public void UpdateCategory(int id, Category per)
        {
            var category = _CategoryEntities.Categories.Find(id);
            category.CategoryID = per.CategoryID;
            category.CategoryCode = per.CategoryCode;
            category.CategoryName = per.CategoryName;
            _CategoryEntities.Entry(category).State = System.Data.Entity.EntityState.Modified;
            _CategoryEntities.SaveChanges();
        }
        #endregion
    }
}