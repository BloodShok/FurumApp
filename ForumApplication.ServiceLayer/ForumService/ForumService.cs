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

        public void DeleteElement(int id)
        {
            _repo.DeleteItemById(id);
            _repo.SaveChanges();
        }

        public IList<ForumDto> GetAllElements()
        {
            var ForumList = _repo.GetAllIncludeReferences();

            return Mapper.Map<IList<ForumDto>>(ForumList); 
        }

        public ForumDto GetElement(int id)
        {
            
            var Forumitem = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<ForumDto>(Forumitem);
        }

        public void SaveElement(SaveNewForumContainerDto item)
        {
            var ForumElement = Mapper.Map<Forum>(item);
            
            _repo.AddNewItem(ForumElement);
            _repo.SaveChanges();
        }
    }
}
