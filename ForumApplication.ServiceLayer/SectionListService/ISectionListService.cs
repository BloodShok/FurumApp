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
        SectionListDto GetElement(int id);
        IList<SectionListDto> GetAllElements();
    }
}
