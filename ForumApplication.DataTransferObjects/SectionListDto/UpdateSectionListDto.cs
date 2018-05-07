using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.SectionListDto
{
    public class UpdateSectionListDto
    {
        
        public int SectionListId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
