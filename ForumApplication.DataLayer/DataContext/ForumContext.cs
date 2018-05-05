using ForumApplication.Domain.Entitys;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ForumApplication.DataLayer.DataContext
{
    public class ForumContext : IdentityDbContext<UserAccount>
    {
        public ForumContext() : base("ForumConnection")
        { }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<SectionList> SectionLists { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserProfile> UserProfile {get;set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public static ForumContext Create()

        {
            return new ForumContext();
        }
        
    }
}
