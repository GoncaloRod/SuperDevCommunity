namespace SuperDevCommunity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gggg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "user_id", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "user_id1", c => c.Int());
            CreateIndex("dbo.Posts", "user_id1");
            AddForeignKey("dbo.Posts", "user_id1", "dbo.Users", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "user_id1", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "user_id1" });
            DropColumn("dbo.Posts", "user_id1");
            DropColumn("dbo.Posts", "user_id");
        }
    }
}
