using ForumApplication.DataTransferObjects.AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.ApiDto
{
    public class ProfileInfoApiDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public UserProfileInfoDto UserProfile { get; set; }
    }
}
