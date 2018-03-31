using SuperDevCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperDevCommunity.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment, int? id)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.Find(int.Parse(User.Identity.Name));

                comment.userId = user.id;
                comment.postId = (int)id;
                comment.createdAt = DateTime.Now;

                db.Comments.Add(comment);
                db.SaveChanges();
            }

            return Redirect("/posts/details/" + id);
        }

        public ActionResult LikeComment(int? id)
        {
            int userId = int.Parse(User.Identity.Name);
            
            // Check if user didn't liked this comment
            bool liked = db.CommentLikes.Where(l => l.commentId == id).Any(l => l.userId == userId);

            if (!liked)
            {
                CommentLike like = new CommentLike();
                like.commentId = (int)id;
                like.userId = userId;
                like.createdAt = DateTime.Now;

                Comment comment = db.Comments.Find(id);
                comment.likes++;

                db.CommentLikes.Add(like);
                db.SaveChanges();

                if (Request.QueryString["url"] == null)
                {
                    return Redirect("/posts/details/" + comment.post.id);
                }
                else
                {
                    return Redirect(Request.QueryString["url"]);
                }
            }

            return Redirect("/");
        }

        public ActionResult UnlikeComment(int? id)
        {
            int userId = int.Parse(User.Identity.Name);

            // Check if user liked this comment
            bool liked = db.CommentLikes.Where(l => l.commentId == id).Any(l => l.userId == userId);

            if (liked)
            {
                CommentLike like = db.CommentLikes.Where(l => l.commentId == id).Single(l => l.userId == userId);

                Comment comment = db.Comments.Find(id);
                comment.likes--;

                db.CommentLikes.Remove(like);
                db.SaveChanges();
                
                if (Request.QueryString["url"] == null)
                {
                    return Redirect("/posts/details/" + comment.post.id);
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