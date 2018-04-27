
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
        public ForumService(IForumRepository repository, IUserProfileRepository accRepo)
        {
            _repo = repository;
            _accRepo = accRepo;
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
            var ForumList = _repo.GetAllIncludeReferences();

            return Mapper.Map<IList<BaseForumContainerInfoDto>>(ForumList); 
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
    }
}
