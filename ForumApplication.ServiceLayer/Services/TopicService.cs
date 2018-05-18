using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
        IPostRepository _postRepo;
        public TopicService(ITopicRepository repository, IUserProfileRepository accRepo, IPostRepository postRepository)
        {
            _topicRepo = repository;
            _accRepo = accRepo;
            _postRepo = postRepository;
        }

        public void CreateTopic(CreateTopicDto newCreateTopicData)
        {
            var newTopic = Mapper.Map<Topic>(newCreateTopicData);
           newTopic.UserId = _accRepo.GetProfileIdByAccountId(newCreateTopicData.UserAccountId);
            _topicRepo.AddNewItem(newTopic);
            _topicRepo.SaveChanges();
        }

        public void DeleteTopic(int id)
        {
            _topicRepo.DeleteItemById(id);
            _topicRepo.SaveChanges();
        }

        public int GetCountOfPostByTopicId(int id)
        {
            return _postRepo.GetCountOfPosts(id);
        }

        public TopicInfoDto GetElement(int id)
        {
            var TopicElement = _topicRepo.GetByIDIncludeReferences(id);
            TopicElement.Posts = _postRepo.GetPostByTopicId(id);

            var topicElementDto = Mapper.Map<TopicInfoDto>(TopicElement);
            return topicElementDto;
        }

        public TopicInfoDto GetElement(int id, int page, int pageSize)
        {
            var topicElement = _topicRepo.GetByIDIncludeReferences(id);
            if (topicElement == null)
                throw new NullReferenceException();

            topicElement.Posts = _postRepo.GetPostByTopicIdPagination(id, page, pageSize);
            var topicElementDto = Mapper.Map<TopicInfoDto>(topicElement);

            return topicElementDto;
        }

        public List<TopicInfoDto> GetListOfTopics()
        {
            var listOfTopic = _topicRepo.GetAllTopicsIncludeUsers();
            var listOfTopicDto = Mapper.Map<List<TopicInfoDto>>(listOfTopic);

            return listOfTopicDto;
        }

        public int GetSectionIdBTopicId(int Id)
        {
            return _topicRepo.GetSectionId(Id);
        }

        public void UpdateTopic(UpdateTopicDto updateTopicDto)
        {
            _topicRepo.Update(updateTopicDto);
            _topicRepo.SaveChanges();
        }
    }
}
