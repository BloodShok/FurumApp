using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.DataTransferObjects.SectionDto;
using ForumApplication.DataTransferObjects.SectionListDto;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.WEB.Models.BaseViewModelItems;
using ForumApplication.WEB.Models.SectionListViewModel;
using ForumApplication.WEB.Models.SectionViewModel;
using ForumApplication.WEB.Models.TopicViewModel;
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

            CreateMap<TopicInfoDto, TopicViewModel.TopicInfoViewModel>()
                .ForMember(topicView => topicView.PostViewModel,
                            opt => opt.MapFrom(topDto => Mapper.Map<IList<PostInfoViewModel>>(topDto.PostDto)));

            CreateMap<PostInfoDto, PostInfoViewModel>();

            CreateMap<LastUpdateTopicInfoDto, LastUpdateTopicInfoViewModel>();

            CreateMap<UserPostInfoDto, UserPostInfoViewModel>();

            CreateMap<CreateSectionListViewModel, CreateSectionListDto>();
            CreateMap<CreateSectionViewModel, CreateSectionDto>();
        }
    }
}