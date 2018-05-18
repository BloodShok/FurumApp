using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApplication.DataLayer.Repository;

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

        public List<Topic> GetAllTopicsIncludeUsers()
        {
            List<Topic> Topic = DbSet
                 .Include(topic => topic.User.UserAccount).ToList();

            return Topic;
        }

        public Topic GetByIDIncludeReferences(int id)
        {
            Topic Topic = DbSet
                 .Include(topic => topic.User.UserAccount)
                 .SingleOrDefault(topic => topic.Id.Equals(id));

            return Topic;
        }

        public int GetSectionId(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id).SectionId;
        }

        public void Update(UpdateTopicDto updateTopicDto)
        {
            Topic topicForUpdate = DbSet.Find(updateTopicDto.TopicId);
            topicForUpdate.Title = updateTopicDto.Title;
            topicForUpdate.DateUpdate = DateTime.Now;
        }
    }
}
