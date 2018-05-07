using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.TopicDto
{
    public class UpdateTopicDto
    {
        public int TopicId { get; set; }
        public string Title { get; set; }
    }
}
