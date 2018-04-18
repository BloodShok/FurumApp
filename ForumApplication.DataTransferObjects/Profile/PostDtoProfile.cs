using AutoMapper;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class PostDtoProfile : AutoMapper.Profile
    {
        public PostDtoProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(postDto => postDto.UserInfo, opt =>
                                        opt.MapFrom(post => Mapper.Map<UserPostInfoDto>(post.User)));
        }
    }
}
