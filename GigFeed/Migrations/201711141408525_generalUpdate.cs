namespace GigFeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generalUpdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Followings", new[] { "followerId" });
            DropIndex("dbo.Followings", new[] { "followeeId" });
            CreateIndex("dbo.Followings", "FollowerId");
            CreateIndex("dbo.Followings", "FolloweeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            CreateIndex("dbo.Followings", "followeeId");
            CreateIndex("dbo.Followings", "followerId");
        }
    }
}
