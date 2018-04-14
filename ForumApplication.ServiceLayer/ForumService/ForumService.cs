using ForumApplication.DataLayer.Repository.CustomRepository;
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ForumApplication.ServiceLayer.ForumService
{
    public class ForumService : IForumService
    {
        DbContext _context;
        public ForumService(DbContext context)
        {
            _context = context;
        }
        public IList<ForumDto> GetAllForumElements()
        {
            ForumRepository frepo = new ForumRepository(_context);
            return frepo.GetAllIncludeReferences();
        }
    }
}
