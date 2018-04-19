using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace ForumApplication.DataTransferObjects.Profile
{
    public class BaseForumContainerProfile : AutoMapper.Profile
    {
        public BaseForumContainerProfile()
        {
            
                CreateMap<Forum, BaseForumContainerDto>()
                    .ForMember(mainDto => mainDto.UserName, opt => opt.MapFrom(forum => forum.User.Login))
                    .ForMember(mainDto => mainDto.NestedItemListInfo , opt => opt.MapFrom(SlistInfo =>
                                                            Mapper.Map<IList<NestedContainerElementsInfoDto>>(SlistInfo.SectionLists)));
            CreateMap<SectionList, BaseForumContainerDto>()
                .ForMember(mainDto => mainDto.UserName, opt => opt.MapFrom(secList => secList.User.Login))
                    .ForMember(mainDto => mainDto.NestedItemListInfo, opt => opt.MapFrom(secList =>
                                                           Mapper.Map<IList<NestedContainerElementsInfoDto>>(secList.Sections)));

            CreateMap<Section, BaseForumContainerDto>()
                .ForMember(mainDto => mainDto.UserName, opt => opt.MapFrom(Sec => Sec.User.Login))
                .ForMember(mainDto => mainDto.NestedItemListInfo, opt =>
                                            opt.MapFrom(Sec => Mapper.Map<IList<NestedContainerElementsInfoDto>>(Sec.Topics)));

            CreateMap<Topic, TopicDto>()
                .ForMember(topDto => topDto.UserName, opt => opt.MapFrom(topic => topic.User.Login))
                .ForMember(topDto => topDto.PostDto, opt => opt.MapFrom(topic => Mapper.Map<IList<PostDto>>(topic.Posts)))
                .ForMember(topDto => topDto.CountOfPosts, opt => opt.MapFrom(topic => topic.Posts.Count));

            CreateMap<Post, PostDto>()
                .ForMember(postDto => postDto.UserInfo, opt =>
                                        opt.MapFrom(post => Mapper.Map<UserPostInfoDto>(post.User)));

        }
    }
}
