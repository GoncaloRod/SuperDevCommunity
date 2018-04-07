using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperDevCommunity.Models;

namespace SuperDevCommunity.Helpers
{
    public static class Utils
    {
        private static SuperDevCommunityContext db = new SuperDevCommunityContext();

        public static User GetUserWithId(this HtmlHelper htmlHelper, int id)
        {
            return db.Users.Find(id);
        }

        public static bool IsPostLiked(this HtmlHelper htmlHelper, int postId, int userId)
        {
            return db.PostLikes.Where(l => l.postId == postId).Where(l => l.userId == userId).ToList().Count == 0;
        }

        public static bool IsCommentLiked(this HtmlHelper htmlHelper, int commentId, int userId)
        {
            return db.CommentLikes.Where(l => l.commentId == commentId).Where(l => l.userId == userId).ToList().Count == 0;
        }

        public static List<Post> TopPosts(this HtmlHelper htmlHelper, int quantity)
        {
            List<Post> posts = db.Posts.Where(p => p.likes > 0).OrderBy(p => p.likes).Take(quantity).ToList();

            return posts;
        }
    }
}