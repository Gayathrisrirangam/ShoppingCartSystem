using ShoppingSystemAPI.Models;
using ShoppingSystemAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingSystemAPI.Controllers
{
    [RoutePrefix("api/Cart")]
    public class CartController : ApiController
    {
        ICart<Cart> _CartRepo;
        public CartController()
        {
            _CartRepo = new CartRepo(new Entities());
        }

        //To get All 
        #region TO GET ALL
        [HttpGet]
        [Route("")]
        public IEnumerable<Cart> GetAll()
        {
            var carts = _CartRepo.GetAll();
            return carts;
        }
        #endregion

        //Data inserting
        #region ADDING 
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(Cart cart)
        {
            Cart userobj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                _CartRepo.Add(cart);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok("saved Successfully");
        }
        #endregion

        //Deleting the existing data
        #region TO DELETE 
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid student id");

                _CartRepo.Delete(id);
            }
            catch
            {
                throw;
            }

            return Ok("Deleted Successfully!");
        }
        #endregion

        //Update Cart
        #region To update Cart
        [HttpPut]
        public IHttpActionResult Update(int id, Cart cart)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid DataList");
                _CartRepo.Update(id, cart);
            }
            catch
            {
                throw;
            }
            return Ok("Updated Successfully");
        }
        #endregion

        //Get cart details by id
        #region TO GET DETAILS BY ID
        //[HttpGet]
        public Cart Get(int id)
        {
            var carts = _CartRepo.Get(id);
            return carts;
        }
        #endregion
    }
}
