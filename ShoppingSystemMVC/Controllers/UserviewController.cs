using Newtonsoft.Json;
using ShoppingSystemMVC.Models;
using ShoppingSystemMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppingSystemMVC.Controllers
{
    public class UserviewController : Controller
    {
        // GET: Userview (getting all details)

        #region Display List of Users
        public async Task<ActionResult> RegisterdUsers()
        {
            List<UserViewModel> users = new List<UserViewModel>();


            var service = new UserServiceRepository();
            {
                using (var response = service.GetResponse("Users"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<UserViewModel>>(apiResponse);
                }
            }
            return View(users);
        }
        #endregion


        //adding users through MVC
        #region
        public async Task<ActionResult> Registration(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = new UserViewModel();
                var service = new UserServiceRepository();
                {
                    using (var response = service.PostResponse("users", userView))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);

                    }
                }
                return RedirectToAction("RegisterdUser");
            }
            return View(userView);
        }
        #endregion

        //to Delete user
        #region DELETE USER
        public async Task<ActionResult> DeleteResponse(int id)
        {
            var service = new UserServiceRepository();
            {
                using(var response = service.DeleteResponse("Users/",id))
                {
                    string apiResponse=await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("RegisterdUser");
        }
        #endregion
    }
}