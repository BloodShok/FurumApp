using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.Profile
{
    public class NewForumContainerModelProfile : AutoMapper.Profile
    {
        public NewForumContainerModelProfile()
        {
            CreateMap<NewForumContainerModel, SaveNewForumContainerDto>();
        }
    }
}