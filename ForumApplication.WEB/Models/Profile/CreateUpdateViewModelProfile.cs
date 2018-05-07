using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.ForumDto;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.DataTransferObjects.SectionListDto;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.WEB.Models.ForumViewModel;
using ForumApplication.WEB.Models.PostViewModel;
using ForumApplication.WEB.Models.SectionListViewModel;
using ForumApplication.WEB.Models.TopicViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class CreateUpdateViewModelProfile : AutoMapper.Profile
    {
        public CreateUpdateViewModelProfile()
        {
            CreateMap<CreateSectionListDto, CreateSectionListViewModel>();
            CreateMap<CreateTopicDto, CreateTopicViewModel>();

            CreateMap<CreatePostViewModel, CreatePostDto>()
                .ForMember(pdto => pdto.MessageStringContent, opt => opt.MapFrom(vm => vm.MessageStringContent));

            CreateMap<UpdateForumViewModel, UpdateForumDto>();

            CreateMap<UpdatePostDto, UpdatePostViewModel>();
        }
    }
}