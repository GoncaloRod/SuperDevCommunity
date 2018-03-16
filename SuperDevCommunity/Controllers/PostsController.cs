using SuperDevCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperDevCommunity.Controllers
{
    public class PostsController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Post post)
        {
            User user = db.Users.Find(int.Parse(User.Identity.Name));

            //post.user = user;
            post.user_id = user.id;

            db.Posts.Add(post);
            db.SaveChanges();

            return View("Index", post);
        }
    }
}