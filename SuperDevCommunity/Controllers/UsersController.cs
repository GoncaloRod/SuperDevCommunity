using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperDevCommunity.Models;

namespace SuperDevCommunity.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();
        
        [AllowAnonymous]
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

        public ActionResult Manage()
        {
            int userId = int.Parse(User.Identity.Name);

            ViewBag.Users = db.Users.Where(u => u.id != userId).ToList();
                
            return View();
        }

        public ActionResult MakeAdmin(int? id)
        {
            if (id != null)
            {
                User user = db.Users.First(u => u.id == id);

                if (user == null) return HttpNotFound();

                user.admin = true;

                db.SaveChanges();

                return RedirectToAction("Manage");
            }
            
            return Redirect("/admin");
        }

        public ActionResult RemoveAdmin(int? id)
        {
            if (id != null)
            {
                User user = db.Users.First(u => u.id == id);

                if (user == null) return HttpNotFound();

                user.admin = false;
                
                db.SaveChanges();

                return RedirectToAction("Manage");
            }
            
            return Redirect("/admin");
        }
    }
}