using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.DataContext.Config
{
    class AccountConfig : EntityTypeConfiguration<UserAccount>
    {
        public AccountConfig()
        {
            HasOptional(acc => acc.UserProfile)
                .WithRequired(prof => prof.UserAccount);
        }
    }
}
