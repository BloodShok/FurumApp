using AutoMapper;
using ForumApplication.DataTransferObjects;
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
            var listofForumsDto = _forumService.GetAllElements();
            var FoumListViewModel = Mapper.Map<List<BaseForumContainerViewModel>>(listofForumsDto);

            return View("List", FoumListViewModel);
        }

        public ActionResult Item(int id)
        {
            var forumItem = _forumService.GetElement(id);

            if (forumItem == null)
                return HttpNotFound();

            var ForumViewModelItem = Mapper.Map<BaseForumContainerViewModel>(forumItem);

            
            return View(ForumViewModelItem);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            var listofForumsDto = _forumService.GetAllElements();
            var FoumListViewModel = Mapper.Map<List<BaseForumContainerViewModel>>(listofForumsDto);

            return View("Delete", FoumListViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _forumService.DeleteElement(id);

            return RedirectToAction("List");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BasePropertysForCreateViewModel newForumData)
        {
            var newForumDataDto = Mapper.Map<BasePropertisForCreateDto>(newForumData);

            _forumService.CreateForum(newForumDataDto);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var updateElemDto = _forumService.GetElement(Id);
            var updateElemViewModel = Mapper.Map<BasePropertisForCreateDto>(updateElemDto);
            
            return View(updateElemViewModel);
        }

        public ActionResult Update(BasePropertysForCreateViewModel updateData)
        {
            var newForumDataDto = Mapper.Map<BasePropertisForCreateDto>(updateData);

            _forumService.CreateForum(newForumDataDto);

            return RedirectToAction("List");
        }
    }
}