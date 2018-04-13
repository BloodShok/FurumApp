using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
    public class User
    {
        public int Id { get;  set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string SomeInformation { get; set; }
        public string Status { get; set; }
        public string AttachedPicture { get; set; }
        public List<Forum> Forums { get; set; } = new List<Forum>();
        public List<SectionList> SectionLists { get; set; } = new List<SectionList>();
        public List<Section> Sections { get; set; } = new List<Section>();
        public List<Topic> Topics { get; set; } = new List<Topic>();
        public List<Post> Posts { get; set; } = new List<Post>();
        
    }

    public enum Gender
    {
        M = 0,
        F = 1
    }
}
