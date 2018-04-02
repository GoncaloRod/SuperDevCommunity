using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
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

            ViewBag.posts = db.Posts.Where(p => p.userId == user.id).ToList();
            ViewBag.comments = db.Comments.Where(c => c.userId == user.id).ToList();
            ViewBag.likes = new List<Post>();

            foreach (var like in db.PostLikes.Where(l => l.userId == user.id))
            {
                ViewBag.likes.Add(db.Posts.Where(p => p.id == like.postId).ToList()[0]);
            }

            return View(user);
        }

        /*
        public ActionResult ChangeProfilePic()
        {
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeProfilePic(User user)
        {
            
        }
        */
    }
}