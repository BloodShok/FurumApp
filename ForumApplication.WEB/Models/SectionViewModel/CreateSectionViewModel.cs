using ForumApplication.WEB.Models.BaseViewModelItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.SectionViewModel
{
    public class CreateSectionViewModel : BasePropertysForCreateViewModel
    {
        public int SectionListId { get; set; }
    }
}