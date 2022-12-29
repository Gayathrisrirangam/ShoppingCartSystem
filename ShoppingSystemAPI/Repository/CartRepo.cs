using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystemAPI.Repository
{
    public class CartRepo : ICart<Cart>
    {
        Entities _cartEntities;
        public CartRepo(Entities context)
        {
            _cartEntities = context;
        }
        //ADD
        #region To Add 
        public void Add(Cart newcart)
        {
            _cartEntities.Carts.Add(newcart);
            _cartEntities.SaveChanges();
        }
        #endregion

        //method to delete 
        #region To Delete 
        public void Delete(int id)
        {
            Cart Ut = _cartEntities.Carts.Find(id);
            _cartEntities.Carts.Remove(Ut);
            _cartEntities.SaveChanges();

        }
        #endregion

        //To Display all 
        #region To Display all
        public IEnumerable<Cart> GetAll()
        {

            return _cartEntities.Carts.ToList();

        }
        #endregion

        //To Display cart by ID
        #region Get Cart Details By ID
        public Cart Get(int id)
        {
            return _cartEntities.Carts.Find(id);

        }
        #endregion

        //To Update Cart
        #region UPDATE Cart
        public void Update(int id, Cart per)
        {
            var cart = _cartEntities.Carts.Find(id);
            cart.CartId = per.CartId;
            cart.ItemID = per.ItemID;
            cart.AddQuantity = per.AddQuantity;
            cart.RemoveQuantity = per.RemoveQuantity;
            _cartEntities.Entry(cart).State = System.Data.Entity.EntityState.Modified;
            _cartEntities.SaveChanges();
        }
        #endregion
    }
}