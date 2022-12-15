using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ShoppingSystemMVC.Models
{
    public class UserViewModel
    {
            [Display(Name = "ProfileID")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Profile ID is required")]
            public int ProfileID { get; set; }

            [Required(ErrorMessage = "FullName is required")]
            [StringLength(50, MinimumLength = 3)][Display(Name = "First Name")] 
            public string FullName { get; set; }

            [Display(Name = "Email Address")]
            [Required(ErrorMessage = "Email Address is required")]
            [StringLength(60)][DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")] 
            public string EmailID { get; set; }

            [Display(Name = "Mobile Number")]
            [StringLength(10)][Required(ErrorMessage = "Mobile Number is required")]
            [RegularExpression("[6-9][0-9]{9}", ErrorMessage = "Mobile Number must begin with 6,7,8 or 9")] 
            public string MobileNumber { get; set; }

            [Display(Name = "Date of birth")]
            [DataType(DataType.Date)]
            [Required(AllowEmptyStrings = false, ErrorMessage = "DOB is required")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime DOB { get; set; }

            [Required(ErrorMessage = "Gender is required")]           
            [Display(Name = "Gender")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [StringLength(10)][DataType(DataType.Password)]
            public string Password { get; set; }

    }


}
