using ShoppingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystemAPI.Repository
{
    public class ItemRepo : IItems<Item>
    {
        Entities _ItemEntities;

        //Constructor Dependancy injection
        Entities _userdbcontext;
        public ItemRepo(Entities context)
        {
            _ItemEntities = context;
        }
        //For Add new ITEM
        #region To Add new ITEM
        public void Add(Item newitem)
        {
            _ItemEntities.Items.Add(newitem);
            _ItemEntities.SaveChanges();
        }
        #endregion

        //method to delete Item
        #region To Delete ITEM
        public void Delete(int id)
        {
           Item Ut = _ItemEntities.Items.Find(id);
            _ItemEntities.Items.Remove(Ut);
            _ItemEntities.SaveChanges();

        }
        #endregion

        //To Display all ITEMS
        #region To Display all ITEMS
        public IEnumerable<Item> GetAll()
        {

            return _ItemEntities.Items.ToList();

        }
        #endregion

        //To Display ITEM by ID
        #region Get ITEM Details By ID
        public Item Get(int id)
        {
            return _ItemEntities.Items.Find(id);

        }
        #endregion

        //To Update ITEM
        #region UPDATE ITEM
        public void Update(int id, Item per)
        {
            var item = _ItemEntities.Items.Find(id);
            item.ItemID = per.ItemID;
            item.CategoryID= per.CategoryID;
            item.ItemCode= per.ItemCode;
            item.ItemName= per.ItemName;
            item.Description= per.Description;
            item.ImagePath= per.ImagePath;
            item.ItemPrice= per.ItemPrice;
            _ItemEntities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _ItemEntities.SaveChanges();
        }
        #endregion
    }
}