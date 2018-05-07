using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.SectionListDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.SectionListService
{
    public interface ISectionListService
    {
        BaseForumContainerInfoDto GetElement(int id);
        IList<BaseForumContainerInfoDto> GetAllElements();
        void CreateSectionList(CreateSectionListDto sectionList);
        void UpdateSectionList(UpdateSectionListDto newSectionListDto);
    }
}
