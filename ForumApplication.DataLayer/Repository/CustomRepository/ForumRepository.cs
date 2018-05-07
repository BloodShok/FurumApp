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
using ForumApplication.DataTransferObjects.ForumDto;

namespace ForumApplication.DataLayer.Repository.CustomRepository
{
    public class ForumRepository : Repository<Forum>, IForumRepository
    {
        public ForumRepository(DbContext context) : base(context)
        {
        }

        public IList<Forum> GetAllIncludeReferences(int pageNumber, int pageSize)
        {
            List<Forum> ListofForum  = DbSet
                .Include(f => f.SectionLists)
                .Include(u => u.User.UserAccount)
                .Page(pageNumber,pageSize)
                .ToList();

            return ListofForum;

        }

        public IList<Forum> GetAllIncludeReferences()
        {
            List<Forum> ListofForum = DbSet.Include(seList => seList
            .SectionLists.Select(sect =>sect.Sections))
                .Include(u => u.User.UserAccount)
                .ToList();

            return ListofForum;
        }

        public Forum GetByIDIncludeReferences(int id)
        {
            Forum ForumElement =  DbSet
                .Include(f => f.SectionLists)
                .Include(u => u.User.UserAccount)
                .SingleOrDefault(forum => forum.Id.Equals(id));

            return ForumElement;
        }

        public void Update(UpdateForumDto updForumDto)
        {
            Forum forumForUpdate = DbSet.Find(updForumDto.ForumId);
            forumForUpdate.Title = updForumDto.Title;
            forumForUpdate.DateUpdate = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
