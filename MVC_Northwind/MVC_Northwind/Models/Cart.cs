using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Northwind.Models
{
    public class Cart
    {
        Dictionary<int, CartItem> _myCart = new Dictionary<int, CartItem>();

        public List<CartItem> myCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void AddItem(CartItem item)//1 Chai 
        {
            if (_myCart.ContainsKey(item.ID))
            {
                _myCart[item.ID].Quantity += 1;
                return;
            }
            _myCart.Add(item.ID, item);
        }
    }
}