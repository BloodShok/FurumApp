using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.SectionDto;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Interfaces
{
    public interface ISectionRepository : IRepository<Section>
    {
        IList<Section> GetAllIncludeReferences();
        IList<Section> GetAllIncludeReferences(int pageNumber, int pageSize);
        Section GetByIDIncludeReferences(int id);
        void Update(UpdateSectionDto updateSectionDto);
    }
}
