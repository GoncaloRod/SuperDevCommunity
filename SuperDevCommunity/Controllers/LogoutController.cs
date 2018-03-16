using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SuperDevCommunity.Models
{
    public class LogoutController : Controller
    {
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoggedOut");
        }

        public ActionResult LoggedOut()
        {
            return RedirectToAction("index", "home");
        }
    }
}