using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApplication.DataLayer.DataContext;
using System.Data.Entity;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;

namespace ForumApplication.DataLayer.Repository.CustomRepository
{
    public class ForumRepository : Repository<Forum>, IForumRepository
    {
        public ForumRepository(DbContext context) : base(context)
        {

        }

        public IList<Forum> GetAllIncludeReferences(int pageNumber, int pageSize)
        {
            List<Forum> ListofForum  = DbSet.Include(f => f.SectionLists
            .Select(x => x.Sections
            .Select(s => s.Topics
            .Select(t => t.Posts)
            )))
            .Include(u => u.User)
            .Page(pageNumber,pageSize)
            .ToList();

            return ListofForum;

        }

        public IList<Forum> GetAllIncludeReferences()
        {
            List<Forum> ListofForum = DbSet.Include(f => f.SectionLists
          .Select(x => x.Sections
          .Select(s => s.Topics
          .Select(t => t.Posts)
          )))
           .Include(u => u.User)
           .ToList();

            return ListofForum;
        }

        public Forum GetByIDIncludeReferences(int id)
        {
            Forum ForumElement =  DbSet.Include(f => f.SectionLists
                .Select(x => x.Sections
                .Select(s => s.Topics
                .Select(t => t.Posts)
                )))
            .Include(u => u.User)
            .SingleOrDefault(forum => forum.Id.Equals(id));

            return ForumElement;
        }
    }
}
