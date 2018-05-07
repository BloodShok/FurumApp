using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.ForumDto;
using ForumApplication.Infrastructure.Consts;
using ForumApplication.ServiceLayer.ForumService;
using ForumApplication.WEB.Models;
using ForumApplication.WEB.Models.BaseViewModelItems;
using ForumApplication.WEB.Models.ForumViewModel;
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
            if(!ModelState.IsValid)
            {
                TempData[TempDataIndexConsts.CreateError] = ErrorConstans.Required;
                return RedirectToAction("List");
            }
            var newForumDataDto = Mapper.Map<BasePropertisForCreateDto>(newForumData);

            _forumService.CreateForum(newForumDataDto);

            return RedirectToAction("List");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Update(UpdateForumViewModel updateData)
        {
            var newForumDataDto = Mapper.Map<UpdateForumDto>(updateData);

            _forumService.UpdateForum(newForumDataDto);

            return RedirectToAction("List");
        }
    }
}