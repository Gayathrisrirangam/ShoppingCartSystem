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
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        IUsers<User> _users;
        public UsersController()
        {
            this._users = new UserRepo(new Entities());
        }

        //Get All
        #region TO GET ALL USERS
        [HttpGet]
        [Route("")]
        public IEnumerable<User> GetAll()
        {
            var users = _users.GetAll();
            return users;
        }
        #endregion

        //Data inserting
        #region ADDING NEW USER
        [HttpPost]
        [Route("")] 
        public IHttpActionResult Post(User user)
        {
            User userobj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                _users.Post(user);
            }
            catch(Exception)
            {
                throw;
            }
            return Ok("saved Successfully");
        }
        #endregion

        //Delete User

        #region Delete user
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not valid ");
                _users.Delete(id);
            }
            catch(Exception)
            {
                throw;
            }
            return Ok("Deleted Successfully");
        }
        #endregion

        //Update user
        #region To update user
        [HttpPut]
        public IHttpActionResult Put(int id, User user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid DataList");
                _users.Put(id,user);
            }
            catch
            {
                throw;
            }
            return Ok("Updated Successfully");
        }
        #endregion

        //Get User details by id
        #region
        [HttpGet]      
        public User GetbyId(int id)
        {
            var users = _users.GetbyId(id);
            return users;
        }
        #endregion
    }
}
