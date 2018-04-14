using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.ProfileDtoModels.QueryObjects
{
    public class ForumDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public string UserName { get; set; }
        public int CountOfPosts { get; set; }
        public int CountOfTopics { get; set; }
    }
}
