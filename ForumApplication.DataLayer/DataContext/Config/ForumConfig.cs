using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.DataLayer.DataAccessContext
{
    class ForumConfig : EntityTypeConfiguration<Forum>
    {
        public ForumConfig()
        {
            ToTable("Forums");

            Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired();
            
        }
    }
}
