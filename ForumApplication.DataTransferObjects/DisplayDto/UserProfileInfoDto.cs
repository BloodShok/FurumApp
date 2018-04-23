using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects
{
    public enum Gender
    {
        M = 0,
        F = 1
    }
    public class UserProfileInfoDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string SomeInformation { get; set; }
        public string AttachedPicture { get; set; }
    }
}
