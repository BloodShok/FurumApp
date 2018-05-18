using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Interfaces
{
    public interface ITopicRepository : IRepository<Topic>
    {
        IList<Topic> GetAllIncludeReferences();
        IList<Topic> GetAllIncludeReferences(int pageNumber, int pageSize);
        Topic GetByIDIncludeReferences(int id);
        void Update(UpdateTopicDto updateTopicDto);
        int GetSectionId(int id);
        List<Topic> GetAllTopicsIncludeUsers();
    }
}
