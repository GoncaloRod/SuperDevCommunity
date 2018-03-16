using SuperDevCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperDevCommunity.Controllers
{
    public class HomeController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Home";
            ViewBag.Posts = db.Posts.OrderByDescending(p => p.created_at).ToList();

            return View();
        }
    }
}