using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.TopicService
{
    public interface ITopicService
    {
        TopicDto GetElement(int id);
        IList<TopicDto> GetAllElements();
    }
}
