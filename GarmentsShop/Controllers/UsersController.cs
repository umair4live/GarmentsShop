using GarmentsShop.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarmentsShop.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel Model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(FormCollection data)
        //{
        //    string id = data["loginid"];
        //    string pass = data["password"];
        //    bool chk = Convert.ToBoolean(data["RememberMe"].Split(',').First());

        //    return View();
        //}
    }
}