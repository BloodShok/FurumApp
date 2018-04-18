using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class SectionListViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public string UserName { get; set; }
        public IList<NestedContainerElement> NestedSectionListInfo { get; set; }
    }
}