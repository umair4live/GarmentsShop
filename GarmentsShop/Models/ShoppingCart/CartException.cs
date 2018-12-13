using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentsShop.Models.ShoppingCart
{
    public class CartException : Exception
    {
        public  CartException() { }
        public CartException(string msg) : base(msg)
        {

        }
    }
}
