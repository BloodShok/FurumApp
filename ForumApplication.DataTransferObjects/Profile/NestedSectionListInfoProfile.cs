using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class NestedSectionListInfoProfile : AutoMapper.Profile
    {
        public NestedSectionListInfoProfile()
        {
            CreateMap<SectionList, NestedSectionItemsInfoDto>()
                .ForMember(destMember => destMember.Id, opt => opt.MapFrom(sl => sl.Id))
                .ForMember(destMember => destMember.Title, opt => opt.MapFrom(sl => sl.Title));
        }
    }
}
