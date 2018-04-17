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

namespace ForumApplication.ServiceLayer.ForumService
{
    public class ForumService : IForumService
    {
        DbContext _context;
        IForumRepository _repo;
        public ForumService(DbContext context,IForumRepository repository)
        {
            _context = context;
            _repo = repository;
        }
        public IList<ForumDto> GetAllForumElements()
        {
            
            var ForumList = _repo.GetAllIncludeReferences();

            return Mapper.Map<IList<ForumDto>>(ForumList); 
        }

        public ForumDto GetForumElement(int id)
        {
            
            var Forumitem = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<ForumDto>(Forumitem);
        }
    }
}
