using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Repository.CustomRepository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {

        }

        public IList<Post> GetAllIncludeReferences()
        {
            IList<Post> post = DbSet
                .Include(item => item.User.UserAccount)
                .Include(item => item.Topic.Section)
                .ToList();

            return post;
        }

        public IList<Post> GetAllIncludeReferences(int pageNumber, int pageSize)
        {
            IList<Post> post = DbSet
                .Include(item => item.User.UserAccount)
                .Page(pageNumber, pageSize)
                .ToList();

            return post;
        }

        public Post GetByIDIncludeReferences(int id)
        {
            Post post = DbSet
                .Include(item => item.User.UserAccount)
                .FirstOrDefault(item => item.Id.Equals(id));
            return post;
        }

        public int GetCountOfPosts(int id)
        {
            return DbSet.Where(x => x.TopicId == id).Count();
        }

        public List<Post> GetPostByTopicIdPagination(int id, int page, int pageSize)
        {
            List<Post> posts = DbSet
                .Where(x => x.TopicId == id)
                .Include(x => x.User.UserAccount)
                .OrderBy(x => x.DateCreated)
                .Page(page, pageSize)
                .ToList();
            return posts;
        }

        public int GetTopicId(int postId)
        {
            return DbSet.Find(postId).TopicId;
        }

        public void Update(UpdatePostDto postDto)
        {
            Post postForUpdate = DbSet.Find(postDto.PostId);
            postForUpdate.MessageStringContent = postDto.MessageStringContent;
            postForUpdate.DateUpdate = DateTime.Now;
        }
    }
}
