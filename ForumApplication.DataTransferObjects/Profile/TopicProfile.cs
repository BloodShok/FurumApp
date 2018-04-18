using AutoMapper;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class TopicProfile : AutoMapper.Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, TopicDto>()
                .ForMember(topDto => topDto.UserName, opt => opt.MapFrom(topic => topic.User.Login))
                .ForMember(topDto => topDto.PostDto, opt => opt.MapFrom(topic => Mapper.Map<IList<PostDto>>(topic.Posts)));
                

                

                
        }
    }
}
