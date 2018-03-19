using SuperDevCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SuperDevCommunity.Controllers
{
    public class PostsController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Post post)
        {
            User user = db.Users.Find(int.Parse(User.Identity.Name));

            //post.user = user;
            post.userid = user.id;

            db.Posts.Add(post);
            db.SaveChanges();

            return RedirectToAction("details", post.id);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Post post = db.Posts.Find(id);

            if (post == null) return HttpNotFound();

            return View(post);
        }
    }
}