using ForumApplication.DataTransferObjects.BaseDtoItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.SectionDto
{
    public class CreateSectionDto : BasePropertisForCreateDto
    {
        public int SectionListId { get; set; }
    }
}
