using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects
{
    public class UpdateUserProfileDto
    {
        public string AccountId { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string SomeInformation { get; set; }
        public string Location { get; set; }
    }
}
