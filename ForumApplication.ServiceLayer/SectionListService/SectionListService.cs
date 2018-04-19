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
        public IList<BaseForumContainerDto> GetAllElements()
        {
            var SectionListElements = _repo.GetAllIncludeReferences();

            return Mapper.Map<IList<BaseForumContainerDto>>(SectionListElements);
        }

        public BaseForumContainerDto GetElement(int id)
        {
            var SectionListElement = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<BaseForumContainerDto>(SectionListElement);
        }
    }
}
