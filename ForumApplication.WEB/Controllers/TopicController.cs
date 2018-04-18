using AutoMapper;
using ForumApplication.ServiceLayer.TopicService;
using ForumApplication.WEB.Models;
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
            var topicView = Mapper.Map<TopicViewModel>(topicDto);
            

            return View(topicView);
        }
    }
}