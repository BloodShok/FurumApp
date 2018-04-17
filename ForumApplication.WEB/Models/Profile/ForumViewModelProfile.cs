using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class ForumViewModelProfile : AutoMapper.Profile
    {
        public ForumViewModelProfile()
        {
            CreateMap<ForumViewModel, ForumDto>();
            CreateMap<ForumDto, ForumViewModel>();
        }
    }
}