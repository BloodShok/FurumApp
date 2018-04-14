using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApplication.DataAccessLayer.DataContext;
using System.Data.Entity;
using ForumApplication.DataLayer.ProfileDtoModels.QueryObjects;
using ForumApplication.DataLayer.ProfileDtoModels.Mapper;

namespace ForumApplication.DataLayer.Repository.CustomRepository
{
    public class ForumRepository : Repository<Forum>, IRepository<Forum>
    {
        public ForumRepository(DbContext context) : base(context)
        {

        }

        public List<Forum> GetAllIncludeReferences()
        {
            return DbSet.Include(f => f.SectionLists
            .Select(x => x.Sections
            .Select(s => s.Topics
            .Select(t => t.Posts)))).ToList();
        }

        public Forum GetByIDIncludeReferences(int id)
        {
            return DbSet.Include(f => f.SectionLists
            .Select(x => x.Sections
            .Select(s => s.Topics
            .Select(t => t.Posts)))).SingleOrDefault(x => x.Id == id);
        }

        public ForumDto GetForumDto(int id)
        {
            ForumDtoMapper dtoMapper = new ForumDtoMapper();
            return dtoMapper.SelectForumDto(GetByIDIncludeReferences(id));
        }
    }
}
