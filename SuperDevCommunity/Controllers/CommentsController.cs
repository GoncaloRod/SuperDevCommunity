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
            CommentLike like = new CommentLike();
            like.commentId = (int)id;
            like.userId = int.Parse(User.Identity.Name);
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
    }
}