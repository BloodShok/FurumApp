using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
    public class Topic
    {
        public int Id { get;  set; }
        public int SectionId { get; set; }
        public int UserId { get; set; }       
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
        public Section Section { get; set; }
        public User User { get; set; }
    }
}
