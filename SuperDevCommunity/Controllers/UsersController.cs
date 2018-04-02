using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperDevCommunity.Models;

namespace SuperDevCommunity.Controllers
{
    public class UsersController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        public ActionResult Profile(int? id)
        {
            if (User.Identity.IsAuthenticated) if (id == int.Parse(User.Identity.Name)) return Redirect("/profile");

            User user = db.Users.Find(id);

            if (user == null) return HttpNotFound();

            ViewBag.posts = db.Posts.Where(p => p.userId == user.id).ToList();
            ViewBag.comments = db.Comments.Where(c => c.userId == user.id).ToList();
            ViewBag.likes = new List<Post>();

            foreach (var like in db.PostLikes.Where(l => l.userId == user.id))
            {
                ViewBag.likes.Add(db.Posts.Where(p => p.id == like.postId).ToList()[0]);
            }

            return View(user);
        }
    }
}