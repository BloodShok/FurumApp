using AutoMapper;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class SectionProfile : AutoMapper.Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionDto>()
                .ForMember(secDto => secDto.UserName, opt => opt.MapFrom(sec => sec.User.Login))
                .ForMember(secDto => secDto.NestedTopicListInfo, opt =>
                                            opt.MapFrom(sec => Mapper.Map<IList<NestedContainerElement>>(sec.Topics)));
        }
    }
}
