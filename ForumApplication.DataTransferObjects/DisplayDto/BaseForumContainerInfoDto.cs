using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects
{
    public class BaseForumContainerInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public IList<NestedContainerElementsInfoDto> NestedItemListInfo { get; set; }
        public UserNameIdDto UserInfo { get; set; }
    }
}
