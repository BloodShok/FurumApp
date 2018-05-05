using ForumApplication.DataTransferObjects.TopicDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.BaseDtoItems
{
    public class NestedContainerElementsInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountOfNestedElements { get; set; }
        public LastUpdateTopicInfoDto LastUpdateTopic { get; set; }
    }
}
