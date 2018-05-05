using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.SectionListDto;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.ServiceLayer.SectionListService
{
    public class SectionListService : ISectionListService
    {
        ISectionListRepository _sectionListRepo;
        IPostRepository _postRepo;
        IUserProfileRepository _accRepo;
        public SectionListService(ISectionListRepository repository, IPostRepository postRepo, IUserProfileRepository profileRepository)
        {
            _sectionListRepo = repository;
            _postRepo = postRepo;
            _accRepo = profileRepository;
        }

        public void CreateSectionList(CreateSectionListDto sectionList)
        {
            var newSectionList = Mapper.Map<SectionList>(sectionList);

            newSectionList.UserId = _accRepo.GetProfileIdByAccountId(sectionList.UserAccountId);
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
            var postsList = _postRepo.GetAllIncludeReferences();

            foreach (var item in sectionList.NestedItemListInfo)
            {
                var lastCreatedPost = postsList
                    .Where(x => x.Topic.SectionId == item.Id)
                    .OrderByDescending(x => x.DateCreated)
                    .FirstOrDefault();

                item.LastUpdateTopic = Mapper.Map<LastUpdateTopicInfoDto>(lastCreatedPost);
            }
        }
    }
}
