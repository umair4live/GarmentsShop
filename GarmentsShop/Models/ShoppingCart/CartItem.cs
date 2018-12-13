using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentsShop.Models.ShoppingCart
{
    public class CartItem : IComparable<CartItem> 
    {
        public CartItem()
        {
            Quantity = 1;
        }

        public int Id { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public int SizeId { get; set; }

        public int Amount {
            get { return (int)(Price * Quantity); }
        }


        public int CompareTo(CartItem other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"CartItem: {Id},{Name},{Price},{Quantity},{Amount}";
        }
    }
}
