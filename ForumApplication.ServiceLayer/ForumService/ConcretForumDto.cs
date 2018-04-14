using ForumApplication.DataLayer.ProfileDtoModels.Mapper;
using ForumApplication.DataLayer.ProfileDtoModels.QueryObjects;
using ForumApplication.DataLayer.Repository.CustomRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.ForumService
{
  public  class ConcretForumDto
    {
        DbContext _context;

        public ConcretForumDto(DbContext context)
        {
            _context = context;
        }
        public ForumDto SelectForumDto(int id)
        {
            ForumRepository repo = new ForumRepository(_context);
            return repo.GetForumDto(id);

            
        }
    }
}
