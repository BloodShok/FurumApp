using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.PostDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.TopicDto
{
    public class TopicInfoDto 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public IList<PostInfoDto> PostDto { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
