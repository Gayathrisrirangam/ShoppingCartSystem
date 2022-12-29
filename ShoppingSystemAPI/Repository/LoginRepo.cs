using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystemAPI.Repository
{
    public class LoginRepo : Ilogin
    {
        private readonly Entities _LoginEntities;

        //Constructor Dependancy injection
        public LoginRepo(Entities loginentities)
        {
            this._LoginEntities = loginentities;
        }
        public User VerifyLogin(string emailID, string password)
        {
            User user = null;
            try
            {
                var userFound = _LoginEntities.Users.Where(u => u.EmailID == emailID && u.Password == password).SingleOrDefault();

                if (userFound != null)
                {
                    user = userFound;
                }
                else
                {
                    user = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }
    }
}