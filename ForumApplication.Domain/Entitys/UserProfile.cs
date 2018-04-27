using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
    public class UserProfile
    {
        public int Id { get;  set; }
        public string Location { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? DateRegistration { get; set; }
        public Gender Gender { get; set; }
        public string SomeInformation { get; set; }
        public string Image { get; set; }
        public List<Forum> Forums { get; set; } = new List<Forum>();
        public List<SectionList> SectionLists { get; set; } = new List<SectionList>();
        public List<Section> Sections { get; set; } = new List<Section>();
        public List<Topic> Topics { get; set; } = new List<Topic>();
        public List<Post> Posts { get; set; } = new List<Post>();

        public UserAccount UserAccount { get; set; }
    }

    public enum Gender
    {
        M = 0,
        F = 1
    }
}
