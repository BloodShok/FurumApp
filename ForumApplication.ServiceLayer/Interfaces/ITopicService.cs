using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.TopicDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.TopicService
{
    public interface ITopicService
    {
        TopicInfoDto GetElement(int id);
        void CreateTopic(CreateTopicDto newCreateTopicData);
        void UpdateTopic(UpdateTopicDto updateTopicDto);
        TopicInfoDto GetElement(int id, int page, int pageSize);
        int GetCountOfPostByTopicId(int id);
        void DeleteTopic(int id);
        List<TopicInfoDto> GetListOfTopics();
        int GetSectionIdBTopicId(int Id);
    }
}
