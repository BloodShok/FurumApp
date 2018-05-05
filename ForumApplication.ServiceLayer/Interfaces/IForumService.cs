using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.ForumDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.ForumService
{
    public interface IForumService
    {
        IList<BaseForumContainerInfoDto> GetAllElements();
        BaseForumContainerInfoDto GetElement(int id);
        void DeleteElement(int id);
        void CreateForum(BasePropertisForCreateDto newForumDataDto);
        void UpdateForum(UpdateForumDto updForumDto);
    }
}
