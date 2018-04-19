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
        ISectionRepository _repo;
        public SectionService(DbContext context, ISectionRepository repository)
        {
            _repo = repository;
        }
        public IList<BaseForumContainerDto> GetAllElements()
        {
           
            var SectionList = _repo.GetAllIncludeReferences();

            return Mapper.Map<IList<BaseForumContainerDto>>(SectionList);
        }

        public BaseForumContainerDto GetElement(int id)
        {
            
            var SectionElement = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<BaseForumContainerDto>(SectionElement);
        }
    }
}
