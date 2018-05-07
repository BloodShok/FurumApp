using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.PostDto
{
    public class UpdatePostDto
    {
        public int PostId { get; set; }
        public string MessageStringContent { get; set; }
    }
}
