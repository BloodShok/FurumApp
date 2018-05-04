using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.WEB.Models.PostViewModel;
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
        }
    }
}