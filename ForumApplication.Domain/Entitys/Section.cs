using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
    public class Section
    {
        public int Id { get;  set; }
        public int SectionListId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }

        public List<Topic> Topics { get; set; } = new List<Topic>();
        public SectionList SectionList { get; set; }
        public UserProfile User { get; set; }

    }
}
