using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataLayer.Repository.CustomRepository;
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.Domain.Entitys;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.DataTransferObjects.SectionDto;

namespace ForumApplication.ServiceLayer.SectionService
{
    public class SectionService : ISectionService
    {
        ISectionRepository _sectionRepo;
        IUserProfileRepository _accRepo;
        IPostRepository _postRepo;
        public SectionService( ISectionRepository repository, IPostRepository postRepo, IUserProfileRepository accountRepo)
        {
            _sectionRepo = repository;
            _postRepo = postRepo;
            _accRepo = accountRepo;
        }

        public void CreateSection(CreateSectionDto createSectionDto)
        {
            var newSection = Mapper.Map<Section>(createSectionDto);
            newSection.UserId = _accRepo.GetProfileIdByAccountId(createSectionDto.UserAccountId);
            _sectionRepo.AddNewItem(newSection);
            _sectionRepo.SaveChanges();
        }

        public IList<BaseForumContainerInfoDto> GetAllElements()
        {
           
            var SectionList = _sectionRepo.GetAllIncludeReferences();

            return Mapper.Map<IList<BaseForumContainerInfoDto>>(SectionList);
        }

        public BaseForumContainerInfoDto GetElement(int id)
        {
            
            var SectionElement = _sectionRepo.GetByIDIncludeReferences(id);

            if (SectionElement == null)
                throw new NullReferenceException();

            var sectionElementDto = Mapper.Map<BaseForumContainerInfoDto>(SectionElement);
            InsertLastUpdateTopic(sectionElementDto);

            return sectionElementDto;
        }

        public void UpdateSection(UpdateSectionDto updateSectionDto)
        {
            _sectionRepo.Update(updateSectionDto);
            _sectionRepo.SaveChanges();
        }

        private void InsertLastUpdateTopic(BaseForumContainerInfoDto section)
        {
            var postsList = _postRepo.GetAllIncludeReferences();

            foreach (var item in section.NestedItemListInfo)
            {
                var lastCreatedPost = postsList
                    .Where(x => x.TopicId == item.Id)
                    .OrderByDescending(x => x.DateCreated)
                    .FirstOrDefault();

                item.LastUpdateTopic = Mapper.Map<LastUpdateTopicInfoDto>(lastCreatedPost);
            }
        }
    }
}
