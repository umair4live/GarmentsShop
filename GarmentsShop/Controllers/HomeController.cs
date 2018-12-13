using GarmentsShop.Models.Products;
using GarmentsShop.Models;
using System;
using GShop;
using GShop.GarmentsShop;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarmentsShop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<SummaryModel> modelsList = new GarmentsHandler().GetProducts().ToSummaryModelList();
            return View(modelsList);
        }
    }
}