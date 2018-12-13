using GarmentsShop.Models;
using GarmentsShop.Models.Products;
using System;
using GShop;
using System.Collections.Generic;
using GShop.GarmentsShop;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarmentsShop.Controllers
{
    public class ProductsController : Controller
    {

        [HttpGet]
        public ActionResult Details(int id)
        {
            DetailsModel model = new GarmentsHandler().GetProduct(id).ToDetailsModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult ByCategory(int id)
        {
            ByCategoryModel model = new GarmentsHandler().GetCategory(id).ToByCategoryModel();
            return View(model);
        }




    }
}