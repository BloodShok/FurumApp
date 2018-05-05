using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.AccountDto
{
    public class TableAccountInfoDto : UserAccountInfoDto
    {
        public bool IsActive { get; set; }
    }
}
