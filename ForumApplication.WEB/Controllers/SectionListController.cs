using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.SectionListDto;
using ForumApplication.ServiceLayer.SectionListService;
using ForumApplication.WEB.Models;
using ForumApplication.WEB.Models.BaseViewModelItems;
using ForumApplication.WEB.Models.SectionListViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumApplication.WEB.Controllers
{
    public class SectionListController : Controller
    {
        ISectionListService _sectionListService;
        public SectionListController(ISectionListService sectionListService)
        {
            _sectionListService = sectionListService;
        }
        // GET: SectionList
        public ActionResult Item(int id)
        {
            var SecListItemDto = _sectionListService.GetElement(id);
            var SecListItemVieweModel = Mapper.Map<BaseForumContainerViewModel>(SecListItemDto);

            return View(SecListItemVieweModel);
        }

        public ActionResult Create(CreateSectionListViewModel createSectionList)
        {
            var newForumDataDto = Mapper.Map<CreateSectionListDto>(createSectionList);

            _sectionListService.CreateSectionList(newForumDataDto);

            return RedirectToAction("List");
        }
    }
}