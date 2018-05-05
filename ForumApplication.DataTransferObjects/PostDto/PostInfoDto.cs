using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.PostDto
{
    public class PostInfoDto
    {
        public int Id { get; set; }
        public string MessageStringContent { get; set; }
        public string AttachedPicture { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public UserPostInfoDto UserPostInfo { get; set; }
    }
}
