namespace SuperDevCommunity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentLikes",
                c => new
                    {
                        key = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        commentId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.key)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.Comments", t => t.commentId, cascadeDelete: false)
                .Index(t => t.userId)
                .Index(t => t.commentId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        likes = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        postId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.Posts", t => t.postId, cascadeDelete: false)
                .Index(t => t.userId)
                .Index(t => t.postId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        likes = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: false)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        retryPassword = c.String(nullable: false),
                        profilePic = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        postId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.postId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: false)
                .Index(t => t.userId)
                .Index(t => t.postId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentLikes", "commentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "postId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "userId", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "userId", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "postId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "userId", "dbo.Users");
            DropForeignKey("dbo.CommentLikes", "userId", "dbo.Users");
            DropIndex("dbo.PostLikes", new[] { "postId" });
            DropIndex("dbo.PostLikes", new[] { "userId" });
            DropIndex("dbo.Posts", new[] { "userId" });
            DropIndex("dbo.Comments", new[] { "postId" });
            DropIndex("dbo.Comments", new[] { "userId" });
            DropIndex("dbo.CommentLikes", new[] { "commentId" });
            DropIndex("dbo.CommentLikes", new[] { "userId" });
            DropTable("dbo.PostLikes");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.CommentLikes");
        }
    }
}
