using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Northwind.Models
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? SubTotal
        {
            get
            {
                return Price * Quantity;

            }
        }
        public decimal? _total;
        public decimal? Total {
            get 
            {
                return _total;
            }
            set 
            {
                 _total += SubTotal;
            }
        }
    }
}