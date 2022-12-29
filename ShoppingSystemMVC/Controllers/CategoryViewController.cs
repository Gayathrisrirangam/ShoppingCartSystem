using Newtonsoft.Json;
using ShoppingSystemMVC.Models;
using ShoppingSystemMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppingSystemMVC.Controllers
{
    public class CategoryViewController : Controller
    {
        //// GET: CategoryView
         public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CategoryDetails()
        {
            List<CategoryViewModel> Category = new List<CategoryViewModel>();
            var service = new UserServiceRepository();
            {
                using (var response = service.GetResponse("Category"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Category = JsonConvert.DeserializeObject<List<CategoryViewModel>>(apiResponse);
                }
            }
            return View(Category);
        }

        public async Task<ActionResult> ItemDetails()
        {
            List<ItemViewModel> Item = new List<ItemViewModel>();
            var service = new UserServiceRepository();
            {
                using (var response = service.GetResponse("Item"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<List<ItemViewModel>>(apiResponse);
                }
            }
            return View(Item);
        }

        public async Task<ActionResult> CartDetails()
        {
            List<CartViewModel> Cart = new List<CartViewModel>();
            var service = new UserServiceRepository();
            {
                using (var response = service.GetResponse("Cart"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Cart = JsonConvert.DeserializeObject<List<CartViewModel>>(apiResponse);
                }
            }
            return View(Cart);
        }

        //adding through MVC
        #region ADD TO CART
        public async Task<ActionResult> AddCart(CartViewModel cartView)
        {
            if (ModelState.IsValid)
            {
                CartViewModel cart = new CartViewModel();
                var service = new UserServiceRepository();
                {
                    using (var response = service.PostResponse("Cart", cartView))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //user = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
              //  return RedirectToAction("CartDetails");
            }
            return View(cartView);
        }
        #endregion


    }
}