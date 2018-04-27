using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class JtableAccountInfoViewModel : UserAccountsInfoViewModel
    {
        [DisplayName("Status")]
        public bool IsActive { get; set; }
    }
}