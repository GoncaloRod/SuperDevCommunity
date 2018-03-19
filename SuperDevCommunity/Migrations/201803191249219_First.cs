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
                        userid = c.Int(nullable: false),
                        commentid = c.Int(nullable: false),
                        createdat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.key)
                .ForeignKey("dbo.Comments", t => t.commentid, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: false)
                .Index(t => t.userid)
                .Index(t => t.commentid);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        userid = c.Int(nullable: false),
                        postid = c.Int(nullable: false),
                        createdat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.postid, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: false)
                .Index(t => t.userid)
                .Index(t => t.postid);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        userid = c.Int(nullable: false),
                        createdat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: false)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        retryPassword = c.String(nullable: false),
                        profilepic = c.String(),
                        createdat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userid = c.Int(nullable: false),
                        postid = c.Int(nullable: false),
                        createdat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.postid, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: false)
                .Index(t => t.userid)
                .Index(t => t.postid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostLikes", "userid", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "postid", "dbo.Posts");
            DropForeignKey("dbo.CommentLikes", "userid", "dbo.Users");
            DropForeignKey("dbo.CommentLikes", "commentid", "dbo.Comments");
            DropForeignKey("dbo.Comments", "userid", "dbo.Users");
            DropForeignKey("dbo.Comments", "postid", "dbo.Posts");
            DropForeignKey("dbo.Posts", "userid", "dbo.Users");
            DropIndex("dbo.PostLikes", new[] { "postid" });
            DropIndex("dbo.PostLikes", new[] { "userid" });
            DropIndex("dbo.Posts", new[] { "userid" });
            DropIndex("dbo.Comments", new[] { "postid" });
            DropIndex("dbo.Comments", new[] { "userid" });
            DropIndex("dbo.CommentLikes", new[] { "commentid" });
            DropIndex("dbo.CommentLikes", new[] { "userid" });
            DropTable("dbo.PostLikes");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.CommentLikes");
        }
    }
}
