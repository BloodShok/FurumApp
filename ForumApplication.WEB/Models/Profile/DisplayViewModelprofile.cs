using AutoMapper;
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class DisplayViewModelProfile : AutoMapper.Profile
    {
        public DisplayViewModelProfile()
        {
            CreateMap<UserPostInfoDto, UserPostInfoViewModel>();

            CreateMap<PostInfoDto, PostViewModel>()
                .ForMember(postDto => postDto.UserInfo,
                            opt => opt.MapFrom(postDto => Mapper.Map<UserPostInfoViewModel>(postDto.UserInfo)));

            CreateMap<TopicInfoDto, TopicViewModel>()
                .ForMember(topicView => topicView.PostViewModel, opt =>
                                    opt.MapFrom(topicDto => Mapper.Map<IList<PostViewModel>>(topicDto.PostDto)));

           
        }
    }
}