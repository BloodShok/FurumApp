using ForumApplication.DataTransferObjects;
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

    }
}
