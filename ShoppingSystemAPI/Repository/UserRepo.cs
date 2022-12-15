using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystemAPI.Repository
{
    public class UserRepo : IUsers<User>
    {
        Entities _userdbcontext;
        public UserRepo(Entities context)
        {
            _userdbcontext = context;
        }

        //To get All Users details
        #region GET ALL USERS 

        public IEnumerable<User> GetAll()
        {
            return _userdbcontext.Users.ToList();

        }
        #endregion

        //To add New User
        #region TO ADD USER
        public void Post(User a)
        {
            _userdbcontext.Users.Add(a);
            _userdbcontext.SaveChanges();
        }
        #endregion

        //method to delete user
        #region To Delete User
        public void Delete(int id)
        {
            User Ut = _userdbcontext.Users.Find(id);
            _userdbcontext.Users.Remove(Ut);
            _userdbcontext.SaveChanges();

        }
        #endregion

        //Method to Update User
        #region UPDATE USER
        public void Put(int id, User per)
        {
            var user_ = _userdbcontext.Users.Find(id);
            user_.ProfileID = per.ProfileID;
            user_.FullName = per.FullName;
            user_.EmailID = per.EmailID;
            user_.MobileNumber = per.MobileNumber;
            user_.DOB = per.DOB;
            user_.Gender = per.Gender;
            user_.Password = per.Password;
            _userdbcontext.Entry(user_).State = System.Data.Entity.EntityState.Modified;
            _userdbcontext.SaveChanges();
        }
        #endregion

        //To get Particular User details by ProfileID
        #region GET BY ID 
        public User GetbyId(int id)
        {
            return _userdbcontext.Users.Find(id);

        }
        #endregion


    }
}