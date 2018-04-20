using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.ServiceLayer.TopicService
{
    public class TopicService : ITopicService
    {
        ITopicRepository _repo;
        public TopicService(ITopicRepository repository)
        {
            _repo = repository;
        }

        public void CreateTopic(CreateTopicDto newCreateTopicData)
        {
            var newTopic = Mapper.Map<Topic>(newCreateTopicData);
            newTopic.DateCreated = DateTime.Now;
            newTopic.DateUpdate = DateTime.Now;

            _repo.AddNewItem(newTopic);
        }

        public IList<TopicInfoDto> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public TopicInfoDto GetElement(int id)
        {
            var TopicElement = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<TopicInfoDto>(TopicElement);
        }
    }
}
