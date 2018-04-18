using ForumApplication.DataLayer.Interfaces;
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
                .Include(item => item.User)
                .ToList();

            return post;
        }

        public IList<Post> GetAllIncludeReferences(int pageNumber, int pageSize)
        {
            IList<Post> post = DbSet
                .Include(item => item.User)
                .Page(pageNumber, pageSize)
                .ToList();

            return post;
        }

        public Post GetByIDIncludeReferences(int id)
        {
            Post post = DbSet
                .Include(item => item.User)
                .FirstOrDefault(item => item.Id.Equals(id));
            return post;
        }
    }
}
