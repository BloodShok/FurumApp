using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataLayer.Repository.CustomRepository;
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ForumApplication.ServiceLayer.SectionService
{
    public class SectionService : ISectionService
    {
        DbContext _context;
        ISectionRepository _repo;
        public SectionService(DbContext context, ISectionRepository repository)
        {
            _context = context;
            _repo = repository;
        }
        public IList<SectionDto> GetAllElements()
        {
           
            var SectionList = _repo.GetAllIncludeReferences();

            return Mapper.Map<IList<SectionDto>>(SectionList);
        }

        public SectionDto GetElement(int id)
        {
            
            var SectionElement = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<SectionDto>(SectionElement);
        }
    }
}
