namespace ForumApplication.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMegration1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfiles", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Login", c => c.String());
        }
    }
}
