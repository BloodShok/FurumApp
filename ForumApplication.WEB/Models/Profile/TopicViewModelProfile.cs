using AutoMapper;
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class TopicViewModelProfile : AutoMapper.Profile
    {
        public TopicViewModelProfile()
        {
            CreateMap<TopicInfoDto, TopicViewModel>()
                .ForMember(topicView => topicView.PostViewModel, opt => 
                                    opt.MapFrom(topicDto => Mapper.Map<IList<PostViewModel>>(topicDto.PostDto)));
        }
    }
}