using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
    public class SectionList
    {
        public int Id { get;  set; }
        public int ForumId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }

        public List<Section> Sections { get; set; } = new List<Section>();
        public Forum Forum { get; set; }
        public User User { get; set; }
    }
}