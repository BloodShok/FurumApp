using AutoMapper;
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class PostViewModelProfile : AutoMapper.Profile
    {
        public PostViewModelProfile()
        {
            CreateMap<PostInfoDto, PostViewModel>()
                .ForMember(postDto => postDto.UserInfo,
                            opt => opt.MapFrom(postDto => Mapper.Map<UserPostInfoViewModel>(postDto.UserInfo)));
        }
    }
}