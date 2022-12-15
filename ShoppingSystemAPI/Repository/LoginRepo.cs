using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystemAPI.Repository
{
    public class LoginRepo : Ilogin
    {
        Entities _LoginEntities = null;
        public User VerifyLogin(string EmailID, string Password)
        {
            User user = null;
            try
            {
                var checkValidUser = _LoginEntities.Users.Where(m => m.EmailID == EmailID && m.Password == Password).FirstOrDefault();
                if (checkValidUser != null)
                {
                    user = checkValidUser;
                }

                else
                {
                    user = null;
                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        public LoginRepo(Entities loginentities)
        {
            this._LoginEntities = loginentities;
        }

    }
}