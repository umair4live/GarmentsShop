using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GarmentsShop.Models;
using GShop.GarmentsShop;
using GarmentsShop.WebUI;
using System.Web.Optimization;
using System.Web.Routing;

namespace GarmentsShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            List<MenuModel> menuItems = new GarmentsHandler().GetDepartments().ToMenuModelList();
            HttpContext.Current.Application.Add(WebUIHelper.MENU_ITEMS, menuItems);
        }



    }
}
