using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ForumApplication.DataAccessLayer.DataContext
{
  public  class ForumContext : System.Data.Entity.DbContext
    {
        public ForumContext() : base("ForumConnection")
        { }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<SectionList> SectionLists { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
