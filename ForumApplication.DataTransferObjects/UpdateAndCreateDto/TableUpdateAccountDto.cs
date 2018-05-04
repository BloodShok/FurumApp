using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects
{
    public class TableUpdateAccountDto : TableCreateAccountDto
    {
        public string Id { get; set; }
    }
}
