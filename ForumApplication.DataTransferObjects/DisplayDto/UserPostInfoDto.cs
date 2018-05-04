using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects
{
    public class UserPostInfoDto : UserNameIdDto
    {
        public string Image { get; set; }
        public DateTime DateRegestration { get; set; }
    }
}
