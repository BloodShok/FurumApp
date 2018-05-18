using AutoMapper;
using ForumApplication.DataTransferObjects.SectionDto;
using ForumApplication.ServiceLayer.SectionService;
using ForumApplication.WEB.Models.BaseViewModelItems;
using ForumApplication.WEB.Models.SectionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForumApplication.WEB.Controllers.API
{
    public class SectionController : ApiController
    {
        ISectionService _sectionService;
        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }
        // GET api/<controller>
        public List<BaseForumContainerViewModel> Get()
        {
            var itemsListDto = _sectionService.GetAllElements();
            var itemsViewModel = Mapper.Map<List<BaseForumContainerViewModel>>(itemsListDto);

            return itemsViewModel;
        }

        // GET api/<controller>/5
        public BaseForumContainerViewModel Get(int id)
        {
            var sectionDto = _sectionService.GetElement(id);
            
            return Mapper.Map<BaseForumContainerViewModel>(sectionDto);
        }

        // POST api/<controller>
        public void Post(CreateSectionViewModel createSectionView)
        {
            var creaeSectionDto = Mapper.Map<CreateSectionDto>(createSectionView);
            _sectionService.CreateSection(creaeSectionDto);
        }

        // PUT api/<controller>/5
        public void Put(UpdateSectionViewModel updateSectionView)
        {
            var updateSectionDto = Mapper.Map<UpdateSectionDto>(updateSectionView);
            _sectionService.UpdateSection(updateSectionDto);
        }
    }
}