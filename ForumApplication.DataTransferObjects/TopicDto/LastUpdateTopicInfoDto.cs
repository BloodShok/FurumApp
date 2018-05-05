using ForumApplication.DataTransferObjects.BaseDtoItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.TopicDto
{
    public class LastUpdateTopicInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
