using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects
{
    public class SectionDto
    {
        public int Id { get; set; }
        public int SectionListId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public int CountOfPosts { get; set; }
        public int CountOfTopics { get; set; }
        public string UserName { get; set; }
        public IList<NestedTopicItemsInfoDto> NestedTopicListInfo { get; set; }
    }
}
