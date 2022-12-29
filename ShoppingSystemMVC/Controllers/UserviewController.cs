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

        public ActionResult loginHomepage()
        {
            return View();
        }

        #region LOGINUSER
        //This Action method is used to display Login View
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> LoginUser(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoginModel newUser = new LoginModel();
                    var service = new UserServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<LoginModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {

            }
            return RedirectToAction("CategoryDetails", "CategoryView");

        }

        #endregion
        public ActionResult LoginUserZ()
        {
            return View();
        }

        //This Post Method will validate the userName & Password valid or not using WebAPI

        #region USER LOGIN
        [Route("")]
        [HttpPost]
        public ActionResult LoginUserZ(UserViewModel Ur)
        {
            if (!(string.IsNullOrEmpty(Ur.EmailID) || string.IsNullOrEmpty(Ur.Password)))
            {

                if (!ModelState.IsValid)
                {
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("https://localhost:44335/api/Login"); // URL for Login WebAPI
                    var checkLoginDetails = hc.PostAsJsonAsync<UserViewModel>("Login", Ur);//Asynchronosly passing the values in Json Format to API
                    var checkrec = checkLoginDetails.Result;//Checking the User EmailID & Password 

                    //Condition for Successfull Login We need to Navigate to Flght Seach Page 
                    if ((int)checkrec.StatusCode == 200)
                    {
                        ViewBag.message = "Login Success!!";
                    }
                    //Condition for Invalid User Name & Password
                    if ((int)checkrec.StatusCode == 426)
                    {
                        ViewBag.message = "Invalid EmailID & Password";
                    }
                }
            }
            return RedirectToAction("CategoryDetails", "CategoryView");

        }
        #endregion
        //Logoff user
        #region LOGOFF 
        public ActionResult LogOff()
        {

            //Session.Remove("UserID");

            FormsAuthentication.SignOut();
            return RedirectToAction("LoginUser");

        }
        #endregion
    }
}