using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.AccountDto
{
    public class TableUpdateAccountDto : TableCreateAccountDto
    {
        public string Id { get; set; }
    }
}
