using Microsoft.AspNet.Identity;
using ShoppingSystemAPI.Models;
using ShoppingSystemAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace ShoppingSystemAPI.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        ICategory<Category> _CategoryRepository;
        
        public CategoryController()
        {
            _CategoryRepository = new CategoryRepo(new Entities());
        }

        //To get All Categories
        #region TO GET ALL CATEGORIES
        [HttpGet]
        [Route("")]
        public IEnumerable<Category> GetAllCategorys()
        {
            var categories = _CategoryRepository.GetAllCategorys();
            return categories;
        }
        #endregion

        //Category Data inserting
        #region ADDING NEW CATEGORY
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddCategory(Category category)
        {
            User userobj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                _CategoryRepository.AddCategory(category);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok("saved Successfully");
        }
        #endregion

        //Deleting the existing data
        #region TO DELETE CATEGORY
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid student id");

                _CategoryRepository.DeleteCategory(id);
            }
            catch
            {
                throw;
            }

            return Ok("Deleted Successfully!");
        }
        #endregion

        //Update category
        #region To update CATEGORY
        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, Category user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid DataList");
                _CategoryRepository.UpdateCategory(id, user);
            }
            catch
            {
                throw;
            }
            return Ok("Updated Successfully");
        }
        #endregion

        //Get Category details by id
        #region TO GET DETAILS BY ID
        //[HttpGet]
        public Category GetCategory(int id)
        {
            var categorys = _CategoryRepository.GetCategory(id);
            return categorys;
        }
        #endregion
    }
}
