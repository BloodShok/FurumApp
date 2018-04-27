﻿using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        int GetProfileIdByAccountId(string accId);
    }
}
