using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.SectionDto;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Repository.CustomRepository
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(DbContext context) : base(context)
        {

        }

        public IList<Section> GetAllIncludeReferences()
        {
            IList<Section> ListOfSections = DbSet
                .Include(sec => sec.Topics
                .Select(top => top.Posts))
                .Include(sec => sec.User.UserAccount).ToList();

            return ListOfSections;
        }

        public IList<Section> GetAllIncludeReferences(int pageNumber, int pageSize)
        {
            IList<Section> ListOfSections = DbSet
                .Include(sec => sec.Topics
                .Select(top => top.Posts))
                .Include(sec => sec.User.UserAccount)
                .Page(pageNumber, pageSize)
                .ToList();

            return ListOfSections;
        }

        public Section GetByIDIncludeReferences(int id)
        {
            Section Section = DbSet
                .Include(sec => sec.Topics
                .Select(top => top.Posts))
                .Include(sec => sec.User.UserAccount)
                .SingleOrDefault(section => section.Id.Equals(id));

            return Section;
        }

        public void Update(UpdateSectionDto updateSectionDto)
        {
            Section sectionForUpdate = DbSet.Find(updateSectionDto.SectionId);
            sectionForUpdate.Title = updateSectionDto.Title;
            sectionForUpdate.DateUpdate = DateTime.Now;
        }
    }
}
