using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.SectionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.SectionService
{
    public interface ISectionService
    {
        BaseForumContainerInfoDto GetElement(int id);
        IList<BaseForumContainerInfoDto> GetAllElements();
        void CreateSection(CreateSectionDto createSectionDto);
    }
}
