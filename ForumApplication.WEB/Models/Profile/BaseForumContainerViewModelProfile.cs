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
            CreateMap<BaseForumContainerDto, BaseForumContainerViewModel>();
        }
    }
}