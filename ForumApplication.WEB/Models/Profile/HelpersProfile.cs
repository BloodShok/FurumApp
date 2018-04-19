using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class HelpersProfile : AutoMapper.Profile
    {
        public HelpersProfile()
        {
            CreateMap<CreateForumContainerModel, CreateNewForumContainerDto>();
            CreateMap<UpdateForumContainerViewModel, UpdateForumContainerDto>();
        }
    }
}