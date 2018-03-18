using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperDevCommunity.Models;

namespace SuperDevCommunity.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        public ActionResult Index()
        {
            User user = db.Users.Find(int.Parse(User.Identity.Name));

            return View(user);
        }
    }
}