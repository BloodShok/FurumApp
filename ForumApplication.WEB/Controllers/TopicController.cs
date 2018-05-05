using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.ServiceLayer.TopicService;
using ForumApplication.WEB.Models;
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
        public ActionResult Item(int id)
        {
            var topicDto = _topicService.GetElement(id);
            var topicView = Mapper.Map<TopicInfoViewModel>(topicDto);
            

            return View(topicView);
        }

        [HttpPost]
        public ActionResult Create(CreateTopicViewModel createTopicView)
        {
            var createTopicDto = Mapper.Map<CreateTopicDto>(createTopicView);
            _topicService.CreateTopic(createTopicDto);

            return RedirectToAction("Item","Section", new { createTopicView.SectionId });
        }
    }
}