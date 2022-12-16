using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ShoppingSystemMVC.Models
{
    public class LoginModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [StringLength(60)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}