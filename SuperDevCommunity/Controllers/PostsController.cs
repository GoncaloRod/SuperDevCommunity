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
            if (ModelState.IsValid)
            {
                User user = db.Users.Find(int.Parse(User.Identity.Name));

                post.userId = user.id;

                post.createdAt = DateTime.Now;

                db.Posts.Add(post);
                db.SaveChanges();

                return Redirect("/posts/details/" + post.id);
            }

            return Redirect("/");
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Post post = db.Posts.Where(p => p.id == id).Include(p => p.user).ToList()[0];

            if (post == null) return HttpNotFound();

            ViewBag.Comments = db.Comments.Where(c => c.postId == post.id).ToList();

            return View(post);
        }

        [Authorize]
        public ActionResult LikePost(int? id)
        {
            PostLike like = new PostLike();
            like.postId = (int)id;
            like.userId = int.Parse(User.Identity.Name);
            like.createdAt = DateTime.Now;

            Post post = db.Posts.Find(id);
            post.likes++;

            db.PostLikes.Add(like);
            db.SaveChanges();

            if (Request.QueryString["url"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Redirect(Request.QueryString["url"]);
            }
        }
    }
}