using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
   public class Post 
    {
        public int Id { get;  set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public string MessageStringContent { get; set; }
        public string AttachedPicture { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }

        public User User { get; set; }
        public Topic Topic { get; set; }

    }
}
