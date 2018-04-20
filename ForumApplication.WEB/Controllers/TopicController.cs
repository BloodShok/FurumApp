using AutoMapper;
using ForumApplication.DataTransferObjects;
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

        [HttpGet]
        public ActionResult Create(int Id)
        {
            ViewBag.SectionId = Id;

            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateTopicViewModel createTopicView)
        {
            var createTopicDto = Mapper.Map<CreateTopicDto>(createTopicView);
            _topicService.CreateTopic(createTopicDto);

            return RedirectToAction("Item", new { createTopicDto.Id });
        }
    }
}