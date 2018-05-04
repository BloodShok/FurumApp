using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class CreateUpdateProfile : AutoMapper.Profile
    {
        public CreateUpdateProfile()
        {
            CreateMap<CreateSectionListDto, SectionList>();
            CreateMap<BasePropertisForCreateDto, Forum>();
            CreateMap<CreateTopicDto, Topic>();

            CreateMap<CreatePostDto, Post>()
                .ForMember(pDto => pDto.MessageStringContent, opt => opt.MapFrom(post => post.MessageStringContent.ToString()))
                .ForMember(pDto => pDto.UserId, opt => opt.Ignore());
        }
    }
}
