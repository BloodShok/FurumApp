using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.DataAccessContext
{
    class UserConfig : EntityTypeConfiguration<UserProfile>
    {
        public UserConfig()
        {
            HasMany(x => x.SectionLists)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Sections)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Topics)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            

            HasMany(x => x.Posts)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            Property(x => x.BirthDay)
                .HasColumnType("datetime2")
                .IsOptional();
            Property(x => x.DateRegistration)
                .HasColumnType("datetime2")
                .IsOptional();

            Property(x => x.SomeInformation)
                .IsOptional();

            
        }
    }
}
