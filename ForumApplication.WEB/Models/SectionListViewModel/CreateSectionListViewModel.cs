using ForumApplication.WEB.Models.BaseViewModelItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.SectionListViewModel
{
    public class CreateSectionListViewModel : BasePropertysForCreateViewModel
    {
        public int ForumId { get; set; }
    }
}