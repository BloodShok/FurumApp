using ForumApplication.DataTransferObjects;
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
        //void DeleteSectionList(int id);
        //void UpdateSectionList(UpdateBaseForumDto updateSection);

    }
}
