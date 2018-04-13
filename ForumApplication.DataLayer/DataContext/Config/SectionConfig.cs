using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.DataAccessContext
{
    class SectionConfig : EntityTypeConfiguration<Section>
    {
        public SectionConfig()
        {
            ToTable("Sections");
            Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
