using ForumApplication.DataTransferObjects;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Interfaces
{
    public interface IForumRepository : IRepository<Forum>
    {
        IList<Forum> GetAllIncludeReferences();
        IList<Forum> GetAllIncludeReferences(int pageNumber, int pageSize);
        Forum GetByIDIncludeReferences(int id);
        void UpdateItem(UpdateForumContainerDto forumElement);
    }
}
