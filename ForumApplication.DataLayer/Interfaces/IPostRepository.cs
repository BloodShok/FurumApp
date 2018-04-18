using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IList<Post> GetAllIncludeReferences();
        IList<Post> GetAllIncludeReferences(int pageNumber, int pageSize);
        Post GetByIDIncludeReferences(int id);
    }
}
