using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class BaseForumContainerViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public List<NestedContainerElementsInfoViewModel> NestedItemListInfo { get; set; }
        public UserNameIdViewModel UserInfo { get; set; }
        
    }
}