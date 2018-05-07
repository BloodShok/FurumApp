using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.BaseViewModelItems
{
    public class BaseForumContainerViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public List<NestedContainerElementsInfoViewModel> NestedItemListInfo { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int ParrentId { get; set; }

    }
}