using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.ServiceLayer.SectionListService
{
    public class SectionListService : ISectionListService
    {
        ISectionListRepository _sectionListRepo;
        public SectionListService(ISectionListRepository repository)
        {
            _sectionListRepo = repository;
        }

        public void CreateSectionList(CreateSectionListDto sectionList)
        {
            var newSectionList = Mapper.Map<SectionList>(sectionList);

            _sectionListRepo.AddNewItem(newSectionList);
        }

        public IList<BaseForumContainerInfoDto> GetAllElements()
        {
            var SectionListElements = _sectionListRepo.GetAllIncludeReferences();

            return Mapper.Map<IList<BaseForumContainerInfoDto>>(SectionListElements);
        }

        public BaseForumContainerInfoDto GetElement(int id)
        {
            var SectionListElement = _sectionListRepo.GetByIDIncludeReferences(id);

            return Mapper.Map<BaseForumContainerInfoDto>(SectionListElement);
        }

     
    }
}
