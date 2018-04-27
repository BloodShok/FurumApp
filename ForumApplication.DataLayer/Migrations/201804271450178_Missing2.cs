namespace ForumApplication.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Missing2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "BirthDay", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.UserProfiles", "DateRegistration", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "DateRegistration", c => c.DateTime());
            AlterColumn("dbo.UserProfiles", "BirthDay", c => c.DateTime());
        }
    }
}
