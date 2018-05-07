using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.DataTransferObjects.SectionDto;
using ForumApplication.DataTransferObjects.SectionListDto;
using ForumApplication.DataTransferObjects.TopicDto;
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
            CreateMap<CreateSectionListDto, SectionList>()
                .ForMember(pDto => pDto.DateCreated, opt => opt.UseValue(DateTime.Now))
                .ForMember(pDto => pDto.DateUpdate, opt => opt.UseValue(DateTime.Now));

            CreateMap<BasePropertisForCreateDto, Forum>()
                 .ForMember(pDto => pDto.DateCreated, opt => opt.UseValue(DateTime.Now))
                 .ForMember(pDto => pDto.DateUpdate, opt => opt.UseValue(DateTime.Now));

            CreateMap<CreateSectionDto, Section>()
                .ForMember(pDto => pDto.DateCreated, opt => opt.UseValue(DateTime.Now))
                 .ForMember(pDto => pDto.DateUpdate, opt => opt.UseValue(DateTime.Now));

            CreateMap<CreateTopicDto, Topic>()
                 .ForMember(pDto => pDto.DateCreated, opt => opt.UseValue(DateTime.Now))
                 .ForMember(pDto => pDto.DateUpdate, opt => opt.UseValue(DateTime.Now));

            CreateMap<CreatePostDto, Post>()
                .ForMember(pDto => pDto.MessageStringContent, opt => opt.MapFrom(post => post.MessageStringContent.ToString()))
                .ForMember(pDto => pDto.DateCreated, opt => opt.UseValue(DateTime.Now))
                .ForMember(pDto => pDto.DateUpdate, opt => opt.UseValue(DateTime.Now))
                .ForMember(pDto => pDto.UserId, opt => opt.Ignore());

            CreateMap<Post, UpdatePostDto>()
                .ForMember(pDto => pDto.PostId, opt => opt.MapFrom(p => p.Id));
        }
    }
}
