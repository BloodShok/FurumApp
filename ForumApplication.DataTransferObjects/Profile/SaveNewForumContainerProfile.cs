using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class SaveNewForumContainerProfile : AutoMapper.Profile
    {
        public SaveNewForumContainerProfile()
        {
            CreateMap<CreateNewForumContainerDto, Forum>();
            CreateMap<CreateNewForumContainerDto, SectionList>();
            CreateMap<CreateNewForumContainerDto, Section>();
            CreateMap<CreateNewForumContainerDto, Topic>();
        }
    }
}
