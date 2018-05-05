using ForumApplication.DataTransferObjects.BaseDtoItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.SectionListDto
{
    public class CreateSectionListDto : BasePropertisForCreateDto
    {
        public int ForumId { get; set; }
    }
}
