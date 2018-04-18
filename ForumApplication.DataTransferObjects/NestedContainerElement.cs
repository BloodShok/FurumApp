using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects
{
    public class NestedContainerElement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountOfPosts { get; set; }
        public int CountOfTopics { get; set; }
    }
}
