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

        public ActionResult ChangeProfilePic()
        {
            ViewBag.defaultPics = db.DefaultProfilePics.ToList();
            ViewBag.user = db.Users.Find(int.Parse(User.Identity.Name));

            return View();
        }
        
        [HttpPost]
        public ActionResult SetDefaultProfilePic(DefaultProfilePic pic)
        {
            // Get logged user
            User user = db.Users.Find(int.Parse(User.Identity.Name));

            // Get pic info
            pic = db.DefaultProfilePics.Find(pic.id);

            if (pic != null)
            {
                user.profilePic = pic.imagePath;

                db.SaveChanges();
                
                return Redirect("/profile");

            }

            return RedirectToAction("ChangeProfilePic");
        }

        [HttpPost]
        public ActionResult UploadProfilePic()
        {
            if (Request.Files.Count == 1)
            {
                // https://stackoverflow.com/questions/11063900/determine-if-uploaded-file-is-image-any-format-on-mvc
                
                return Redirect("/profile");
            }
            
            return RedirectToAction("ChangeProfilePic");
        }
    }
}