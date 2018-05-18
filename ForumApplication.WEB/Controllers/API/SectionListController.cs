using AutoMapper;
using ForumApplication.DataTransferObjects.SectionListDto;
using ForumApplication.ServiceLayer.SectionListService;
using ForumApplication.WEB.Models.BaseViewModelItems;
using ForumApplication.WEB.Models.SectionListViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForumApplication.WEB.Controllers.API
{
    public class SectionListController : ApiController
    {
        ISectionListService _sectionListService;

        public SectionListController(ISectionListService sectionListService)
        {
            _sectionListService = sectionListService;
        }
        public List<BaseForumContainerViewModel> Get()
        {
            var itemsListDto = _sectionListService.GetAllElements();
            var itemsViewModel = Mapper.Map<List<BaseForumContainerViewModel>>(itemsListDto);

            return itemsViewModel;
        }

        // GET api/<controller>/5
        public BaseForumContainerViewModel Get(int id)
        {
            var sectionDto = _sectionListService.GetElement(id);

            return Mapper.Map<BaseForumContainerViewModel>(sectionDto);
        }

        // POST api/<controller>
        public void Post(CreateSectionListViewModel createSectionView)
        {
            var creaeSectionDto = Mapper.Map<CreateSectionListDto>(createSectionView);
            _sectionListService.CreateSectionList(creaeSectionDto);
        }

        // PUT api/<controller>/5
        public void Put(UpdateSectionListViewModel updateSectionView)
        {
            var updateSectionDto = Mapper.Map<UpdateSectionListDto>(updateSectionView);
            _sectionListService.UpdateSectionList(updateSectionDto);
        }
    }
}