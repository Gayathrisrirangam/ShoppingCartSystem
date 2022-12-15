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
    }
}