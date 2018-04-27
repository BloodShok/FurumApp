using ForumApplication.DataLayer.Interfaces;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Repository.CustomRepository
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        { }
        
        public int GetProfileIdByAccountId(string accId)
        {
            return DbSet.Include(pr => pr.UserAccount).FirstOrDefault(prof => prof.UserAccount.Id.Equals(accId)).Id;
        }

    }
}
