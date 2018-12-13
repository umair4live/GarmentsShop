using GarmentsShop.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarmentsShop.WebUI;
using System.Web.Mvc;

namespace GarmentsShop.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public ActionResult Details()
        {
            ViewBag.MyCart= (Cart)Session[WebUIHelper.CART];
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            Cart cart = Session[WebUIHelper.CART] as Cart;
            if (cart == null)
            {
                cart = new Cart();
            }
            int productId = Convert.ToInt32(Request.QueryString["pid"]);
            string productName = Request.QueryString["name"];
            int qty = Convert.ToInt32(Request.QueryString["qty"]);
            int price = Convert.ToInt32(Request.QueryString["price"]);
            int sizeId = Convert.ToInt32(Request.QueryString["sid"]);
            string imageUrl= Request.QueryString["image"];
            cart.Add(productId, productName, price, qty, sizeId,imageUrl);
            Session.Add(WebUIHelper.CART, cart);            
            return RedirectToAction("index", "home");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            JsonResult temp = new JsonResult();
            try { 
                //throw new Exception("a test exception");
                Cart cart = Session[WebUIHelper.CART] as Cart;     
                if (cart != null)
                {
                    cart.Remove(id);
                    Session.Add(WebUIHelper.CART, cart);
                    temp.Data = true;
                }
            }
            catch (Exception ex)
            {
                temp.Data = false;
            }
            temp.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return temp;
        }


        [HttpGet]
        public ActionResult UpdateQty()
        {
            JsonResult temp = new JsonResult();
            try
            {
                Cart cart = Session[WebUIHelper.CART] as Cart;
                if (cart != null)
                {
                    int pid = Convert.ToInt32(Request.QueryString["pid"]);
                    int qty = Convert.ToInt32(Request.QueryString["qty"]);
                    cart.UpdateQuantity(pid, qty);
                    Session.Add(WebUIHelper.CART, cart);
                    temp.Data = new { IsUpdated=true, Item= cart.GetItem(pid) };
                }
            }
            catch (Exception ex)
            {
                temp.Data = new { IsUpdated = false };
            }
            temp.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return temp;
        }


    }
}