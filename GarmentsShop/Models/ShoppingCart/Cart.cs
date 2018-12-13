using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentsShop.Models.ShoppingCart
{
    public class Cart : IEnumerable<CartItem>
    {
        private List<CartItem> items;

        public Cart()
        {
            items = new List<CartItem>();
        }

        public void Add(int id,string name,float price,int qty,int sizeId,string imageUrl)
        {
            Add(new CartItem { Id = id, Name = name, Price = price, Quantity = qty, SizeId=sizeId, ImageUrl=imageUrl });
        }


        private void Add(CartItem item)
        {
            if (item.Quantity < 1)
            {
                CartException ex = new CartException("minimum allowed quantity is 1");
                ex.HelpLink = "http://www.evslearning.com/dotnet338/help";
                throw ex;
            }
            if (item.Price < 0)
            {
                CartException ex = new CartException("item price can't b negative");
                ex.HelpLink = "http://www.evslearning.com/dotnet338/help";
                throw ex;
            }
            CartItem found = items.Find(i => i.Id == item.Id);
            if (found == null)
            {
                items.Add(item);
            }
            else
            {
                found.Quantity += item.Quantity;
            }            
        }

      

        public void Remove(int id)
        {
           CartItem found = items.Find(i => i.Id == id);
            if (found != null)
            {
                items.Remove(found);
            }
        }

        public void UpdateQuantity(int id,int qty)
        {
            CartItem found = items.Find(i => i.Id == id);
            if (found != null)
            {
                found.Quantity = qty;
            }            
        }

     
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<CartItem> GetEnumerator()
        {
            return ((IEnumerable<CartItem>)items).GetEnumerator();
        }

        public CartItem GetItem(int id)
        {
            return items[id]; 
        }

        public int NumberOfItems
        {
            get { return items.Count; }
        }

        public int TotalAmount
        {
            get
            {
                int sum = 0;
                foreach (var item in items)
                {
                    sum += item.Amount;
                }
                return sum;
            }
        }

        

    }
}
