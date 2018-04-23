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

            CreateMap<Forum, BaseForumContainerInfoDto>()
                    .ForMember(mainDto => mainDto.NestedItemListInfo,
                            opt => opt.MapFrom(forum => Mapper.Map<IList<NestedContainerElementsInfoDto>>(forum.SectionLists)))
            .ForMember(mainDto => mainDto.UserInfo,
                            opt => opt.MapFrom(forum => Mapper.Map<UserNameIdDto>(forum.User.UserAccount)));


            CreateMap<SectionList, BaseForumContainerInfoDto>()
                    .ForMember(mainDto => mainDto.NestedItemListInfo,
                            opt => opt.MapFrom(secList => Mapper.Map<IList<NestedContainerElementsInfoDto>>(secList.Sections)))
                    .ForMember(mainDto => mainDto.UserInfo,
                            opt => opt.MapFrom(secList => Mapper.Map<UserNameIdDto>(secList.User.UserAccount)));


            CreateMap<Section, BaseForumContainerInfoDto>()
                    .ForMember(mainDto => mainDto.NestedItemListInfo,
                            opt => opt.MapFrom(sec => Mapper.Map<IList<NestedContainerElementsInfoDto>>(sec.Topics)))
                    .ForMember(mainDto => mainDto.UserInfo,
                            opt => opt.MapFrom(sec => Mapper.Map<UserNameIdDto>(sec.User.UserAccount)));


            CreateMap<Topic, TopicInfoDto>()
                   .ForMember(topDto => topDto.PostDto, opt => opt.MapFrom(top => top.Posts))
                   .ForMember(topDto => topDto.UserInfo, opt => opt.MapFrom(top => Mapper.Map<UserNameIdDto>(top.User.UserAccount)))
                   .ForMember(topDto => topDto.CountOfPosts, opt => opt.MapFrom(top => top.Posts.Count))
                   .ForMember(topDto => topDto.PostDto, opt => opt.MapFrom(topic => Mapper.Map<IList<PostInfoDto>>(topic.Posts)));

            CreateMap<Post, PostInfoDto>()
                .ForMember(postDto => postDto.UserInfo,
                        opt => opt.MapFrom(post => Mapper.Map<UserNameIdDto>(post.User.UserAccount)));

            CreateMap<BaseForumContainerInfoDto, Forum>();

        }
    }
}
