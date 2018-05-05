using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class NestedContainerElementsInfoProfile : AutoMapper.Profile
    {
        public NestedContainerElementsInfoProfile()
        {
            CreateMap<SectionList, NestedContainerElementsInfoDto>()
                .ForMember(NesContain => NesContain.CountOfNestedElements, 
                            opt => opt.MapFrom(secList => secList.Sections.Count));

            CreateMap<Section, NestedContainerElementsInfoDto>()
                .ForMember(NesContain => NesContain.CountOfNestedElements,
                            opt => opt.MapFrom(sec => sec.Topics.Count));

            CreateMap<Topic, NestedContainerElementsInfoDto>()
                .ForMember(NesContain => NesContain.CountOfNestedElements,
                            opt => opt.MapFrom(top => top.Posts.Count));
        }

        

    }
}
