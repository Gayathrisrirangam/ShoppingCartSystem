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
    [RoutePrefix("api/Item")]
    public class ItemController : ApiController
    {

        IItems<Item> _Itemrepo;
        public ItemController()
        {
            _Itemrepo = new ItemRepo(new Entities());  
        }

        //To get All ITEMs
        #region TO GET ALL ITEMS
        [HttpGet]
        [Route("")]
        public IEnumerable<Item> GetAll()
        {
            var items = _Itemrepo.GetAll();
            return items;
        }
        #endregion

        //ITEM Data inserting
        #region ADDING NEW ITEM
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(Item item)
        {
            User userobj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                _Itemrepo.Add(item);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok("saved Successfully");
        }
        #endregion

        //Deleting the existing data
        #region TO DELETE ITEM
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid student id");

                _Itemrepo.Delete(id);
            }
            catch
            {
                throw;
            }

            return Ok("Deleted Successfully!");
        }
        #endregion

        //Update ITEM
        #region To update ITEM
        [HttpPut]
        public IHttpActionResult Update(int id, Item user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid DataList");
                _Itemrepo.Update(id, user);
            }
            catch
            {
                throw;
            }
            return Ok("Updated Successfully");
        }
        #endregion

        //Get ITEM details by id
        #region TO GET DETAILS BY ID
        //[HttpGet]
        public Item Get(int id)
        {
            var items = _Itemrepo.Get(id);
            return items;
        }
        #endregion
    }
}
