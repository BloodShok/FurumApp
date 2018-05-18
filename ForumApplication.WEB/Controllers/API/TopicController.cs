using AutoMapper;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.ServiceLayer.TopicService;
using ForumApplication.WEB.Models.TopicViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForumApplication.WEB.Controllers.API
{
    public class TopicController : ApiController
    {
        ITopicService _topicService;
        public TopicController(ITopicService service)
        {
            _topicService = service;
        }
        // GET api/<controller>
        public List<TopicInfoApiViewModel> Get()
        {
            var listOfTopics = _topicService.GetListOfTopics();

            return AutoMapper.Mapper.Map<List<TopicInfoApiViewModel>>(listOfTopics);
        }

        // GET api/<controller>/5
        public TopicInfoViewModel Get(int id)
        {
            var topicDto = _topicService.GetElement(id);
            return Mapper.Map<TopicInfoViewModel>(topicDto);

        }

        // POST api/<controller>
        public void Post(CreateTopicViewModel createTopicView)
        {
            var createTopicDto = Mapper.Map<CreateTopicDto>(createTopicView);
            _topicService.CreateTopic(createTopicDto);
        }

        // PUT api/<controller>/5
        public void Put(UpdateTopicViewModel updateTopicView)
        {
            var updateTopicDto = Mapper.Map<UpdateTopicDto>(updateTopicView);
            _topicService.UpdateTopic(updateTopicDto);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var sectionIdForReidirect = _topicService.GetSectionIdBTopicId(id);
            _topicService.DeleteTopic(id);
        }
    }
}