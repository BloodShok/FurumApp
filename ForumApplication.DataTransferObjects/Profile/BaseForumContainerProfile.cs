using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
namespace ForumApplication.DataTransferObjects.Profile
{
    public class BaseForumContainerProfile : AutoMapper.Profile
    {
        public BaseForumContainerProfile()
        {
            #region BaseContainerMapping

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

            CreateMap<Post, LastUpdateTopicInfoDto>()
               .ForMember(x => x.Id, opt => opt.MapFrom(pt => pt.TopicId))
               .ForMember(x => x.Title, opt => opt.MapFrom(pt => pt.Topic.Title))
               .ForMember(x => x.UserInfo, opt => opt.MapFrom(pt => Mapper.Map<UserNameIdDto>(pt.User.UserAccount)))
               .ForMember(x => x.UpdateTime, opt => opt.MapFrom(pt => pt.DateUpdate));

            CreateMap<BaseForumContainerInfoDto, Forum>();
            #endregion


            #region TopicAndPostMapping

            CreateMap<UserAccount, UserPostInfoDto>()
               .ForMember(usProfile => usProfile.Image, opt => opt.MapFrom(acc => acc.UserProfile.Image))
               .ForMember(usProfile => usProfile.DateRegestration, opt => opt.MapFrom(acc => acc.UserProfile.DateRegistration));

            CreateMap<Post, PostInfoDto>()
                .ForMember(x => x.UserPostInfo, opt => opt.MapFrom(x => x.User.UserAccount));


            CreateMap<Topic, TopicInfoDto>()
                .ForMember(topDto => topDto.PostDto, opt => opt.MapFrom(top => top.Posts))
                .ForMember(topDto => topDto.UserInfo, opt => opt.MapFrom(top => top.User.UserAccount));
                

            #endregion

        }
    }
}
