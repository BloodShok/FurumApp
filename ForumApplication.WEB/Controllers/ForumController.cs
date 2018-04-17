using AutoMapper;
using ForumApplication.ServiceLayer.ForumService;
using ForumApplication.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumApplication.WEB.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        IForumService _forumService;
        public ForumController(IForumService service)
        {
            _forumService = service;
        }
        public ActionResult List()
        {
            var listofForumsDto = _forumService.GetAllForumElements();
            var FoumListViewModel = Mapper.Map<IList<ForumViewModel>>(listofForumsDto);

            return View("List", FoumListViewModel);
        }

        public ActionResult Item(int id)
        {
            var forumItem = _forumService.GetForumElement(id);
            var ForumViewModelItem = Mapper.Map<ForumViewModel>(forumItem);

            return View(ForumViewModelItem);
        }
    }
}