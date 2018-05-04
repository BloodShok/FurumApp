
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;

using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.ServiceLayer.ForumService
{
    public class ForumService : IForumService
    {
        IForumRepository _repo;
        IUserProfileRepository _accRepo;
        IPostRepository _postRepo;
        public ForumService(IForumRepository repository, IUserProfileRepository accRepo, IPostRepository postRepo)
        {
            _repo = repository;
            _accRepo = accRepo;
            _postRepo = postRepo;
        }

        public void CreateForum(BasePropertisForCreateDto newForumDataDto)
        {
            var newForum = Mapper.Map<Forum>(newForumDataDto);
            var profId = _accRepo.GetProfileIdByAccountId(newForumDataDto.UserAccountId);

            newForum.DateCreated = DateTime.Now;
            newForum.DateUpdate = DateTime.Now;
            newForum.UserId = profId;

            _repo.AddNewItem(newForum);
        }

        public void DeleteElement(int id)
        {
            _repo.DeleteItemById(id);
        }

        public IList<BaseForumContainerInfoDto> GetAllElements()
        {
            var forumList = _repo.GetAllIncludeReferences();
            var forumListInfoDto = Mapper.Map<IList<BaseForumContainerInfoDto>>(forumList);
            InsertLastUpdateTopic(forumListInfoDto);

           return Mapper.Map<IList<BaseForumContainerInfoDto>>(forumListInfoDto); 
        }

        public BaseForumContainerInfoDto GetElement(int id)
        {
            
            var Forumitem = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<BaseForumContainerInfoDto>(Forumitem);
        }

        public void UpdateForum(BaseForumContainerInfoDto updForumDto)
        {
            var newForum = Mapper.Map<Forum>(updForumDto);
            newForum.DateCreated = DateTime.Now;
            newForum.DateUpdate = DateTime.Now;

            _repo.AddNewItem(newForum);
        }


        private void InsertLastUpdateTopic(IList<BaseForumContainerInfoDto> forumList)
        {
            foreach (var forum in forumList)
            {
                foreach (var item in forum.NestedItemListInfo)
                {
                    item.LastUpdateTopic = Mapper.Map<LastUpdateTopicInfoDto>(_postRepo.GetLastCreatedPostBySectionListId(item.Id));
                }
            }
        }
    }
}
