using ForumApplication.DataTransferObjects.PostDto;
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
        List<Post> GetPostByTopicIdPagination(int id, int page, int pageSize);

        int GetCountOfPosts(int id);
        void Update(UpdatePostDto postDto);
        int GetTopicId(int postId);
        List<Post> GetPostByTopicId(int id);
    }
}
