using AutoMapper;
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class BaseForumContainerViewModelProfile : AutoMapper.Profile
    {
        public BaseForumContainerViewModelProfile()
        {
            CreateMap<BaseForumContainerInfoDto, BaseForumContainerViewModel>();

            CreateMap<TopicInfoDto, TopicViewModel>()
                .ForMember(topicView => topicView.PostViewModel,
                            opt => opt.MapFrom(topDto => Mapper.Map<IList<PostInfoViewModel>>(topDto.PostDto)));

            CreateMap<PostInfoDto, PostInfoViewModel>();
               // .ForMember(x => x.UserInfo, opt => opt.MapFrom( x => Mapper.Map<UserNameIdViewModel>(x.UserInfo)));

           
                
        }
    }
}