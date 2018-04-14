using AutoMapper;
using ForumApplication.ServiceLayer.ForumService;
using ForumApplication.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ForumApplication.WEB.Controllers
{
    public class HomeController : Controller
    {
        IForumService _forumService;
        public HomeController(IForumService service)
        {
            _forumService = service;
        }
        // GET: Home
        public ActionResult ShowForumList()
        {
            var listofForums = _forumService.GetAllForumElements();
            return View("ShowForumList",listofForums);
        }
    }
}