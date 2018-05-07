using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.ServiceLayer.TopicService;
using ForumApplication.WEB.Models;
using ForumApplication.WEB.Models.Helpers;
using ForumApplication.WEB.Models.TopicViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumApplication.WEB.Controllers
{
    public class TopicController : Controller
    {
        ITopicService _topicService;
        public TopicController(ITopicService service)
        {
            _topicService = service;
        }
        // GET: Topic
        public ActionResult Item(int id, int page = 0)
        {
            var topicPage = new TopicPageViewModel();
           
            int pageSize = 10;

              var topicDto = _topicService.GetElement(id, page * pageSize, pageSize);


            topicPage.TopicInfoView = Mapper.Map<TopicInfoViewModel>(topicDto);
            topicPage.PageInfo = new Page
            {
                CountOfPage = (_topicService.GetCountOfPostByTopicId(id) / pageSize),
                CurrentPage = page
            };
            return View(topicPage); 
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreateTopicViewModel createTopicView)
        {
            var createTopicDto = Mapper.Map<CreateTopicDto>(createTopicView);
            _topicService.CreateTopic(createTopicDto);
           
            return RedirectToAction("Item","Section", new {Id = createTopicView.SectionId });
        }

        [HttpPost]
        [Authorize]
        public ActionResult Update(UpdateTopicViewModel updateTopicView)
        {
            var updateTopicDto = Mapper.Map<UpdateTopicDto>(updateTopicView);
            _topicService.UpdateTopic(updateTopicDto);

            return RedirectToAction("Item", new { Id = updateTopicView.TopicId });
        }

        public ActionResult Delete(int id)
        {
            var sectionIdForReidirect = _topicService.GetSectionIdBTopicId(id);
            _topicService.DeleteTopic(id);

            return RedirectToAction("Item", "Section", new { Id = sectionIdForReidirect });
            
        }
    }
}