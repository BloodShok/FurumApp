using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.DataTransferObjects.Profile
{
   public class ForumProfile : AutoMapper.Profile
    {
        public ForumProfile()
        {
            CreateMap<Forum, ForumDto>()
                .ForMember("UserName", opt => opt.MapFrom(forum => forum.User.Login))
                .ForMember("NestedSectionListItemListInfo", opt => opt.MapFrom(SlistInfo =>
                                                        Mapper.Map<IList<NestedContainerElement>>(SlistInfo.SectionLists)));
        }
    }
    
}
