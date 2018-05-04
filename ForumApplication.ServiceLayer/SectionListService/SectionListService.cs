using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.ServiceLayer.SectionListService
{
    public class SectionListService : ISectionListService
    {
        ISectionListRepository _sectionListRepo;
        IPostRepository _postRepo;
        public SectionListService(ISectionListRepository repository, IPostRepository postRepo)
        {
            _sectionListRepo = repository;
            _postRepo = postRepo;
        }

        public void CreateSectionList(CreateSectionListDto sectionList)
        {
            var newSectionList = Mapper.Map<SectionList>(sectionList);

            newSectionList.DateCreated = DateTime.Now;
            newSectionList.DateUpdate = DateTime.Now;
    
            _sectionListRepo.AddNewItem(newSectionList);
        }

        public IList<BaseForumContainerInfoDto> GetAllElements()
        {
            var SectionListElements = _sectionListRepo.GetAllIncludeReferences();
            var SectionListElementsDto = Mapper.Map<IList<BaseForumContainerInfoDto>>(SectionListElements);
            

            return SectionListElementsDto;
        }

        public BaseForumContainerInfoDto GetElement(int id)
        {
            var SectionListElement = _sectionListRepo.GetByIDIncludeReferences(id);
            
            var sectionlistDto = Mapper.Map<BaseForumContainerInfoDto>(SectionListElement);
            InsertLastUpdateTopic(sectionlistDto);
            return sectionlistDto;
        }

        private void InsertLastUpdateTopic(BaseForumContainerInfoDto sectionList)
        {
                foreach (var item in sectionList.NestedItemListInfo)
                {
                    item.LastUpdateTopic = Mapper.Map<LastUpdateTopicInfoDto>(_postRepo.GetLastCreatedPostBySectionId(item.Id));
                }
        }
    }
}
