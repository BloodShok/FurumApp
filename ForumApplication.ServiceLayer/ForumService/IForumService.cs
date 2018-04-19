using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.ForumService
{
    public interface IForumService
    {
        IList<BaseForumContainerDto> GetAllElements();
        BaseForumContainerDto GetElement(int id);
        void SaveElement(SaveNewForumContainerDto item);
        void DeleteElement(int id);
    }
}
