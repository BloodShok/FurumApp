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
            CreateMap<SaveNewForumContainerDto, Forum>();
            CreateMap<SaveNewForumContainerDto, SectionList>();
            CreateMap<SaveNewForumContainerDto, Section>();
            CreateMap<SaveNewForumContainerDto, Topic>();
        }
    }
}
