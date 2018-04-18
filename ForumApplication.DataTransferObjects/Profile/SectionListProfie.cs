using AutoMapper;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class SectionListProfie : AutoMapper.Profile
    {
        public SectionListProfie()
        {
            CreateMap<SectionList, SectionListDto>()
                .ForMember(SecListDto => SecListDto.UserName, opt => opt.MapFrom(SecList => SecList.User.Login))
                .ForMember(SecListDto => SecListDto.NestedSectionListInfo, opt =>
                                            opt.MapFrom(SecList => Mapper.Map<IList<NestedContainerElement>>(SecList.Sections)
                ));
        }
    }
}
