﻿using ForumApplication.WEB.Models.AccountViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.AdministratorViewModel
{
    public class TableAccountInfoViewModel : UserAccountsInfoViewModel
    {
        [DisplayName("Status")]
        public bool IsActive { get; set; }
    }
}