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

            ViewBag.Likes = db.PostLikes.Where(l => l.postId == post.id).ToList();
            ViewBag.Comments = db.Comments.Where(c => c.postId == post.id).ToList();

            return View(post);
        }

        [Authorize]
        public ActionResult LikePost(int? id)
        {
            int userId = int.Parse(User.Identity.Name);

            // Chek if user didn't liked this post
            bool liked = db.PostLikes.Where(l => l.postId == id).Any(l => l.userId == userId);

            if (!liked)
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
                    return Redirect("/posts/details/" + id);
                }
                else
                {
                    return Redirect(Request.QueryString["url"]);
                }
            }

            return Redirect("/");
        }

        [Authorize]
        public ActionResult UnlikePost(int? id)
        {
            int userId = int.Parse(User.Identity.Name);

            // Chek if user didn't liked this post
            bool liked = db.PostLikes.Where(l => l.postId == id).Any(l => l.userId == userId);

            if (liked)
            {
                PostLike like = db.PostLikes.Where(l => l.postId == id).Single(l => l.userId == userId);

                Post post = db.Posts.Find(id);
                post.likes--;

                db.PostLikes.Remove(like);
                db.SaveChanges();

                if (Request.QueryString["url"] == null)
                {
                    return Redirect("/posts/details/" + id);
                }
                else
                {
                    return Redirect(Request.QueryString["url"]);
                }
            }

            return Redirect("/");
        }
    }
}