using ShoppingSystemAPI.Models;
using ShoppingSystemAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace ShoppingSystemAPI.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        LoginRepo _Loginrepo;
        public LoginController()
        {
            this._Loginrepo = new LoginRepo(new Entities());
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult VerifyLogin(Loginuser login)
        {
            User user = null;
            try
            {
                user = _Loginrepo.VerifyLogin(login.EmailID, login.Password);
                if (user == null)
                    return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(user);
        }
    }
}
