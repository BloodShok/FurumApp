using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class NestedTopicListInfoProfile : AutoMapper.Profile
    {
        public NestedTopicListInfoProfile()
        {
            CreateMap<Topic, NestedTopicItemsInfoDto>()
                .ForMember(nt => nt.Id, opt => opt.MapFrom(topic => topic.Id))
                .ForMember(nt => nt.Title, opt => opt.MapFrom(topic => topic.Title));
        }
    }
}
