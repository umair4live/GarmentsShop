using GarmentsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarmentsShop.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index(string data)
        {

            //HttpContext.Application


            //Session.SessionID
            //Session.Timeout
            //Session.IsNewSession
            //Session.Abandon();
            //Session.Add("key", "any object");
            //dynamic x = Session["key"];
            //Session.Remove("key");
            //Session.Clear();

            //Cookies
            //QueryString / Url Rewriting
            //Hidden Form fields





            


           
            if (!string.IsNullOrWhiteSpace(data))
            {
                string[] names = data.Split(',');

                //ViewData
                ViewBag.Names = names;
                //TempData.Add("Names", names);
            }

            DemoIndexModel m = new DemoIndexModel { CategoryName = "Category-1", ProductName = "AAA", ProductPrice = 100 };
            return View(m);
        }
    }
}