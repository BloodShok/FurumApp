using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;

namespace ForumApplication.ServiceLayer.TopicService
{
    public class TopicService : ITopicService
    {
        ITopicRepository _repo;
        public TopicService(ITopicRepository repository)
        {
            _repo = repository;
        }

        public IList<TopicDto> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public TopicDto GetElement(int id)
        {
            var TopicElement = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<TopicDto>(TopicElement);
        }
    }
}
