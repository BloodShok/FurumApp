using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;

namespace ForumApplication.ServiceLayer.SectionListService
{
    public class SectionListService : ISectionListService
    {
        ISectionListRepository _repo;
        public SectionListService(DbContext context, ISectionListRepository repository)
        {
            _repo = repository;
        }
        public IList<SectionListDto> GetAllElements()
        {
            var SectionListElements = _repo.GetAllIncludeReferences();

            return Mapper.Map<IList<SectionListDto>>(SectionListElements);
        }

        public SectionListDto GetElement(int id)
        {
            var SectionListElement = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<SectionListDto>(SectionListElement);
        }
    }
}
