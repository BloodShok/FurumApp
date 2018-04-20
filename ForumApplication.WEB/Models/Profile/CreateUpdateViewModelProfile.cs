using ForumApplication.DataTransferObjects;
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
        }
    }
}