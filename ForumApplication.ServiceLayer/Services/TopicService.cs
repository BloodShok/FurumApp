using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.ServiceLayer.TopicService
{
    public class TopicService : ITopicService
    {
        IUserProfileRepository _accRepo;
        ITopicRepository _topicRepo;
        public TopicService(ITopicRepository repository, IUserProfileRepository accRepo)
        {
            _topicRepo = repository;
            _accRepo = accRepo;
        }

        public void CreateTopic(CreateTopicDto newCreateTopicData)
        {
            var newTopic = Mapper.Map<Topic>(newCreateTopicData);
           newTopic.UserId = _accRepo.GetProfileIdByAccountId(newCreateTopicData.UserAccountId);
            _topicRepo.AddNewItem(newTopic);
        }

        public TopicInfoDto GetElement(int id)
        {
            var TopicElement = _topicRepo.GetByIDIncludeReferences(id);
            var topicElementDto = Mapper.Map<TopicInfoDto>(TopicElement);
            return topicElementDto;
        }
    }
}
