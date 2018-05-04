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
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
       
        public TopicRepository(DbContext context) : base(context)
        {
            
        }

        public IList<Topic> GetAllIncludeReferences()
        {
            IList<Topic> ListOfTopics = DbSet
                .Include(topic => topic.Posts)
                .Include(topic => topic.User.UserAccount)
                .ToList();

            return ListOfTopics;
        }

        public IList<Topic> GetAllIncludeReferences(int pageNumber, int pageSize)
        {
            IList<Topic> ListOfTopics = DbSet
                .Include(topic => topic.Posts)
                .Include(topic => topic.User.UserAccount)
                .Page(pageNumber,pageSize)
                .ToList();

            return ListOfTopics;
        }

        public Topic GetByIDIncludeReferences(int id)
        {
            Topic Topic = DbSet
                 .Include(topic => topic.User.UserAccount)
                 .Include(topic => topic.Posts
                 .Select(post => post.User.UserAccount))
                 .SingleOrDefault(topic => topic.Id.Equals(id));

            return Topic;
        }
    }
}
