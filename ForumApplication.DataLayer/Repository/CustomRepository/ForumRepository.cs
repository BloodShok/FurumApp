using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApplication.DataAccessLayer.DataContext;
using System.Data.Entity;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;

namespace ForumApplication.DataLayer.Repository.CustomRepository
{
    public class ForumRepository : Repository<Forum>, IRepository<Forum>
    {
        public ForumRepository(DbContext context) : base(context)
        {

        }

        public IList<ForumDto> GetAllIncludeReferences()
        {
            List<Forum> ListofForum  = DbSet.Include(f => f.SectionLists
            .Select(x => x.Sections
            .Select(s => s.Topics
            .Select(t => t.Posts)
            )))
            .Include(u => u.User)
            .ToList();

            return AutoMapper.Mapper.Map<IList<ForumDto>>(ListofForum);

        }

        public ForumDto GetByIDIncludeReferences(int id)
        {
            Forum ForumElement =  DbSet.Include(f => f.SectionLists
                .Select(x => x.Sections
                .Select(s => s.Topics
                .Select(t => t.Posts)
                )))
            .Include(u => u.User)
            .SingleOrDefault(forum => forum.Id == id);

            return AutoMapper.Mapper.Map<ForumDto>(ForumElement);
        } 
    }
}
