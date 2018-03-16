namespace SuperDevCommunity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentAnswerLikes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        comment_answer_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        comment_answer_id1 = c.Int(),
                        user_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CommentAnswers", t => t.comment_answer_id1)
                .ForeignKey("dbo.Users", t => t.user_id1)
                .Index(t => t.comment_answer_id1)
                .Index(t => t.user_id1);
            
            CreateTable(
                "dbo.CommentAnswers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        user_id = c.Int(nullable: false),
                        user = c.Int(nullable: false),
                        comment_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        comment_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Comments", t => t.comment_id1)
                .Index(t => t.comment_id1);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        user_id = c.Int(nullable: false),
                        post_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        post_id1 = c.Int(),
                        user_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.post_id1)
                .ForeignKey("dbo.Users", t => t.user_id1)
                .Index(t => t.post_id1)
                .Index(t => t.user_id1);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        user_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        user_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.user_id1)
                .Index(t => t.user_id1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        retryPassword = c.String(nullable: false),
                        profile_pic = c.String(),
                        created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CommentLikes",
                c => new
                    {
                        key = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        comment_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        comment_id1 = c.Int(),
                        user_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.key)
                .ForeignKey("dbo.Comments", t => t.comment_id1)
                .ForeignKey("dbo.Users", t => t.user_id1)
                .Index(t => t.comment_id1)
                .Index(t => t.user_id1);
            
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        post_id = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        post_id1 = c.Int(),
                        user_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.post_id1)
                .ForeignKey("dbo.Users", t => t.user_id1)
                .Index(t => t.post_id1)
                .Index(t => t.user_id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostLikes", "user_id1", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "post_id1", "dbo.Posts");
            DropForeignKey("dbo.CommentLikes", "user_id1", "dbo.Users");
            DropForeignKey("dbo.CommentLikes", "comment_id1", "dbo.Comments");
            DropForeignKey("dbo.CommentAnswerLikes", "user_id1", "dbo.Users");
            DropForeignKey("dbo.CommentAnswerLikes", "comment_answer_id1", "dbo.CommentAnswers");
            DropForeignKey("dbo.CommentAnswers", "comment_id1", "dbo.Comments");
            DropForeignKey("dbo.Comments", "user_id1", "dbo.Users");
            DropForeignKey("dbo.Comments", "post_id1", "dbo.Posts");
            DropForeignKey("dbo.Posts", "user_id1", "dbo.Users");
            DropIndex("dbo.PostLikes", new[] { "user_id1" });
            DropIndex("dbo.PostLikes", new[] { "post_id1" });
            DropIndex("dbo.CommentLikes", new[] { "user_id1" });
            DropIndex("dbo.CommentLikes", new[] { "comment_id1" });
            DropIndex("dbo.Posts", new[] { "user_id1" });
            DropIndex("dbo.Comments", new[] { "user_id1" });
            DropIndex("dbo.Comments", new[] { "post_id1" });
            DropIndex("dbo.CommentAnswers", new[] { "comment_id1" });
            DropIndex("dbo.CommentAnswerLikes", new[] { "user_id1" });
            DropIndex("dbo.CommentAnswerLikes", new[] { "comment_answer_id1" });
            DropTable("dbo.PostLikes");
            DropTable("dbo.CommentLikes");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.CommentAnswers");
            DropTable("dbo.CommentAnswerLikes");
        }
    }
}
