using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperDevCommunity.Models
{
    public class SuperDevCommunityContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SuperDevCommunityContext() : base("name=SuperDevCommunityContext")
        {
        }

        public System.Data.Entity.DbSet<SuperDevCommunity.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<SuperDevCommunity.Models.Post> Posts { get; set; }
        public System.Data.Entity.DbSet<SuperDevCommunity.Models.PostLike> PostLikes { get; set; }
        public System.Data.Entity.DbSet<SuperDevCommunity.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<SuperDevCommunity.Models.CommentLike> CommentLikes { get; set; }
        public System.Data.Entity.DbSet<SuperDevCommunity.Models.CommentAnswer> CommentAnswers { get; set; }
        public System.Data.Entity.DbSet<SuperDevCommunity.Models.CommentAnswerLike> CommentAnswerLikes { get; set; }
    }
}
