using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ForumApplication.ServiceLayer;
using ForumApplication.ServiceLayer.SectionService;
using ForumApplication.WEB.Models;

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
    }
}