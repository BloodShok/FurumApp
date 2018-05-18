using AutoMapper;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.ForumDto;
using ForumApplication.ServiceLayer.ForumService;
using ForumApplication.WEB.Models.BaseViewModelItems;
using ForumApplication.WEB.Models.ForumViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForumApplication.WEB.Controllers.API
{
    public class ForumController : ApiController
    {
        // GET api/<controller>
        IForumService _forumService;
        public ForumController(IForumService service)
        {
            _forumService = service;
        }
        public List<BaseForumContainerViewModel> Get()
        {
            var itemsListDto = _forumService.GetAllElements();
            var itemsViewModel = Mapper.Map<List<BaseForumContainerViewModel>>(itemsListDto);

            return itemsViewModel;
        }

        // GET api/<controller>/5
        public BaseForumContainerViewModel Get(int id)
        {
            var sectionDto = _forumService.GetElement(id);

            return Mapper.Map<BaseForumContainerViewModel>(sectionDto);
        }

        // POST api/<controller>
        public void Post(BasePropertysForCreateViewModel createSectionView)
        {
            var creaeSectionDto = Mapper.Map<BasePropertisForCreateDto>(createSectionView);
            _forumService.CreateForum(creaeSectionDto);
        }

        // PUT api/<controller>/5
        public void Put(UpdateForumViewModel updateSectionView)
        {
            var updateSectionDto = Mapper.Map<UpdateForumDto>(updateSectionView);
            _forumService.UpdateForum(updateSectionDto);
        }
    }
}