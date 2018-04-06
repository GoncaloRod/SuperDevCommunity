using SuperDevCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SuperDevCommunity.Controllers
{
    public class HomeController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        public ActionResult Index()
        {
            ViewBag.Posts = db.Posts.OrderByDescending(p => p.createdAt).Include(p => p.user).ToList();

            return View();
        }
    }
}