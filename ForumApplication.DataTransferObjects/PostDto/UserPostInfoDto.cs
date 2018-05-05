using ForumApplication.DataTransferObjects.BaseDtoItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.PostDto
{
    public class UserPostInfoDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public DateTime DateRegestration { get; set; }
    }
}
