namespace ForumApplication.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMegration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SectionLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForumId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forums", t => t.ForumId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .Index(t => t.ForumId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionListId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SectionLists", t => t.SectionListId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .Index(t => t.SectionListId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        MessageStringContent = c.String(),
                        AttachedPicture = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .Index(t => t.TopicId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAccountId = c.String(),
                        Login = c.String(),
                        Location = c.String(),
                        BirthDay = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        SomeInformation = c.String(),
                        AttachedPicture = c.String(),
                        UserAccount_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAccount_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserProfileId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Topics", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.UserProfiles", "UserAccount_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Topics", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Sections", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.SectionLists", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Posts", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Forums", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Posts", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Sections", "SectionListId", "dbo.SectionLists");
            DropForeignKey("dbo.SectionLists", "ForumId", "dbo.Forums");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserProfiles", new[] { "UserAccount_Id" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "TopicId" });
            DropIndex("dbo.Topics", new[] { "UserId" });
            DropIndex("dbo.Topics", new[] { "SectionId" });
            DropIndex("dbo.Sections", new[] { "UserId" });
            DropIndex("dbo.Sections", new[] { "SectionListId" });
            DropIndex("dbo.SectionLists", new[] { "UserId" });
            DropIndex("dbo.SectionLists", new[] { "ForumId" });
            DropIndex("dbo.Forums", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Posts");
            DropTable("dbo.Topics");
            DropTable("dbo.Sections");
            DropTable("dbo.SectionLists");
            DropTable("dbo.Forums");
        }
    }
}
