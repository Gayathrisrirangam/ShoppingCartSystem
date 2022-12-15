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
        public IHttpActionResult VerifyLogin(Loginuser objlogin)
        {
            User user = null;
            try
            {
                user = _Loginrepo.VerifyLogin(objlogin.EmailID, objlogin.Password);

                if (user != null)
                {
                    //return NotFound();
                    return Ok(user);

                }

            }
            catch (Exception ex)
            {

            }

            //return Ok(customer);
            return NotFound();

        }
    }
}
