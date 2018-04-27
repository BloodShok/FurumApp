namespace ForumApplication.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Missing1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "DateRegistration", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "DateRegistration", c => c.DateTime(nullable: false));
        }
    }
}
