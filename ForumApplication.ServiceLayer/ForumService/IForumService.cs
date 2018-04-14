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
        IList<ForumDto> GetAllForumElements();
    }
}
