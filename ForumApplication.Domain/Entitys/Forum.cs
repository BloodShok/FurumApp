using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
   public class Forum 
    {
        public int Id { get;  set; }   
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }

        public UserProfile User { get; set; }
        public List<SectionList> SectionLists { get; set; } = new List<SectionList>();

    }
}
