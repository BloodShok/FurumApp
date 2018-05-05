using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.PostDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.PostService
{
    public interface IPostService
    {
        IList<PostInfoDto> GetAllElements();
        PostInfoDto GetElement(int id);
        void CreateNewPost(CreatePostDto createPostDto);
    }
}
