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
                .Include(item => item.User.UserAccount)
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


        public Post GetLastCreatedPostBySectionListId(int sectionListId)
        {

            Post post = DbSet.Where(x => x.Topic
            .Section.SectionListId == sectionListId)
            .OrderByDescending(p => p.DateUpdate)
            .Include(p =>p.Topic)
            .Include(p=>p.User.UserAccount)
            .FirstOrDefault();

            return post;
        }

        public Post GetLastCreatedPostBySectionId(int sectionId)
        {

            Post post = DbSet.Where(x => x.Topic
            .Section.Id == sectionId)
            .OrderByDescending(p => p.DateUpdate)
            .Include(p => p.Topic)
            .Include(p => p.User.UserAccount)
            .FirstOrDefault();

            return post;
        }

        public Post GetLastCreatedPostByTopicId(int topicId)
        {

            Post post = DbSet.Where(x => x.Topic.Id == topicId)
            .OrderByDescending(p => p.DateUpdate)
            .Include(p => p.Topic)
            .Include(p => p.User.UserAccount)
            .FirstOrDefault();

            return post;
        }

    }
}
