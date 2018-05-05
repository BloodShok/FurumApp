using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Repository.CustomRepository
{
    public class SectionListRepository : Repository<SectionList>, ISectionListRepository
    {
        public SectionListRepository(DbContext context) : base(context)
        {

        }

        public IList<SectionList> GetAllIncludeReferences()
        {
            List<SectionList> ListofSectionList = DbSet.Include(sl => sl.Sections
           .Select(s => s.Topics
           .Select(t => t.Posts)))
            .Include(u => u.User.UserAccount)
            .ToList();

            return ListofSectionList;
        }

        public IList<SectionList> GetAllIncludeReferences(int pageNumber, int pageSize)
        {
            List<SectionList> ListofSectionList = DbSet.Include(sl => sl.Sections
          .Select(s => s.Topics
          .Select(t => t.Posts)
          ))
           .Include(u => u.User.UserAccount)
           .Page(pageNumber, pageSize)
           .ToList();

            return ListofSectionList;
        }

        public SectionList GetByIDIncludeReferences(int id)
        {
            SectionList SectionListElement = DbSet.Include(sl => sl.Sections
               .Select(s => s.Topics
               .Select(t => t.Posts)
               ))
            .Include(u => u.User.UserAccount)
            .SingleOrDefault(sl => sl.Id.Equals(id));

            return SectionListElement;
        }


    }
}
