using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystemAPI.Repository
{
    internal interface Ilogin
    {
        User VerifyLogin(string EmailID, string Password);
    }
}
