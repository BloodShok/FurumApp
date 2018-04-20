using ForumApplication.DataLayer.Repository.CustomRepository;
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.ServiceLayer.ForumService
{
    public class ForumService : IForumService
    {
        IForumRepository _repo;
        public ForumService(IForumRepository repository)
        {
            _repo = repository;
        }

        public void CreateForum(BasePropertisForCreateDto newForumDataDto)
        {
            var newForum = Mapper.Map<Forum>(newForumDataDto);
            newForum.DateCreated = DateTime.Now;
            newForum.DateUpdate = DateTime.Now;

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
    }
}
