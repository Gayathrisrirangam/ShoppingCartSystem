using Microsoft.Owin.Security.Provider;
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
using System.Web.Security;

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

        //UPDATE USER
        #region UPDATE USER
       
        #endregion


        //adding users through MVC
        #region REGISTRATION
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
                        //user = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
                return RedirectToAction("LoginUser");
            }
            return View(userView);
        }
        #endregion

        //update user
        #region UPDATE USER
        // GET: users/Edit/5
        //[Authorize(Users = "Ras@gmail.com")]
        public async Task<ActionResult> Edit(int id)
        {
            UserViewModel user = new UserViewModel();
            var service = new UserServiceRepository();
            {
                using (var response = service.GetResponse("Users" + "/" + id))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    user
                        = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
            }
            return View(user);
        }

        // POST: users/Edit/5
        //[Consumes("application/json")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel user)
        {
            UserViewModel updatedUser = new UserViewModel();
            var service = new UserServiceRepository();
            {
                using (var response = service.PutResponse("users"
                + "/" + user.ProfileID, user))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //updatedUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
            }
            return RedirectToAction("RegisterdUsers");
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
            return RedirectToAction("RegisterdUser","Userview");
        }
        #endregion

        //Starting Page
        #region HOMEPAGE
        public ActionResult HomePage()
        {
            return View();
        }
        #endregion

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "EmailID, Password")]LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserViewModel newUser = new UserViewModel();
                    var service = new UserServiceRepository();
                    {
                        using (var response = service.PostResponse("Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(login.EmailID, false);
                        return RedirectToAction("CategoryDetails", "CategoryView");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "The Email or Password provided is incorrect";
                    }
                }
            }
            catch
            {

            }
            return View();

        }

        public ActionResult LogOff()
        {

            //Session.Remove("UserID");

            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
    }
}