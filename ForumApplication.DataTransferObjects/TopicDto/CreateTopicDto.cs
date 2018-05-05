using ForumApplication.DataTransferObjects.BaseDtoItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.TopicDto
{
    public class CreateTopicDto : BasePropertisForCreateDto
    {
        public int SectionId { get; set; }
    }
}
