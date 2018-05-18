using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ForumApplication.DataTransferObjects.SectionDto;
using ForumApplication.ServiceLayer;
using ForumApplication.ServiceLayer.SectionService;
using ForumApplication.WEB.Models;
using ForumApplication.WEB.Models.BaseViewModelItems;
using ForumApplication.WEB.Models.SectionViewModel;

namespace ForumApplication.WEB.Controllers
{
    public class SectionController : Controller
    {
        ISectionService _sectionService;
        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        // GET: Section
        public ActionResult Item(int id)
        {
            var SectionDto = _sectionService.GetElement(id);
            var SectionView = Mapper.Map<BaseForumContainerViewModel>(SectionDto);

            return View(SectionView);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Moderator")]
        public ActionResult Create(CreateSectionViewModel createSection)
        {
            var createSectionDto = Mapper.Map<CreateSectionDto>(createSection);
            _sectionService.CreateSection(createSectionDto);
            return RedirectToAction("Item","SectionList", new { Id = createSection.SectionListId });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Moderator")]
        public ActionResult Update(UpdateSectionViewModel updateSectionView)
        {
            var updateSectionDto = Mapper.Map<UpdateSectionDto>(updateSectionView);
            _sectionService.UpdateSection(updateSectionDto);

            return RedirectToAction("Item", "Section", new { Id = updateSectionView.SectionId });
        }
    }
}