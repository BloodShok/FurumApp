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
        public ActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Add (CreateForumContainerModel NewContainerModel)
        //{
        //    var newForumDto = Mapper.Map<CreateNewForumContainerDto>(NewContainerModel);

        //    _forumService.SaveElement(newForumDto);

        //    return RedirectToAction("List");
        //}

        [HttpGet]
        public ActionResult Delete()
        {
            var listofForumsDto = _forumService.GetAllElements();
            var FoumListViewModel = Mapper.Map<List<BaseForumContainerViewModel>>(listofForumsDto);

            return View("Delete", FoumListViewModel);
        }

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    _forumService.DeleteElement(id);

        //    return RedirectToAction("List");
        //}

        //[HttpGet]
        //public ActionResult Update(int id)
        //{
        //    var itemForUpdateDto = _forumService.GetElement(id);
        //    var itemForUpadateView = Mapper.Map<BaseForumContainerViewModel>(itemForUpdateDto);

        //    return View(itemForUpadateView);
        //}

        //[HttpPost]
        //public ActionResult Update(UpdateForumContainerViewModel modelForUpdate)
        //{
        //    var itemForUpdateDto = Mapper.Map<UpdateBaseForumDto>(modelForUpdate);
        //    _forumService.UpdateForum(itemForUpdateDto);

        //    return RedirectToAction("List");
        //}

    }
}