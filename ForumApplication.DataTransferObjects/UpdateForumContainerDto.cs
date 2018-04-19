using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects
{
    public class UpdateForumContainerDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
