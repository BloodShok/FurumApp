using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.DataAccessContext
{
    class SectionListConfig : EntityTypeConfiguration<SectionList>
    {
        public SectionListConfig()
        {
            ToTable("SectionLists");
            Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
