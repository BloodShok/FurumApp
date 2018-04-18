using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.PostService
{
    public interface IPostService
    {
        IList<PostDto> GetAllElements();
        PostDto GetElement(int id);
    }
}
