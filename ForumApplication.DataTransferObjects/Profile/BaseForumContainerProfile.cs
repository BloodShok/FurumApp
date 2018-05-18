using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using ForumApplication.DataTransferObjects.BaseDtoItems;
using ForumApplication.DataTransferObjects.TopicDto;
using ForumApplication.DataTransferObjects.PostDto;

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
                    .ForMember(mainDto => mainDto.UserId,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.Id))
                    .ForMember(mainDto => mainDto.UserName,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.UserName));

            CreateMap<SectionList, BaseForumContainerInfoDto>()
                    .ForMember(mainDto => mainDto.NestedItemListInfo,
                            opt => opt.MapFrom(secList => Mapper.Map<IList<NestedContainerElementsInfoDto>>(secList.Sections)))
                    .ForMember(mainDto => mainDto.UserId,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.Id))
                    .ForMember(mainDto => mainDto.ParrentId,
                           opt => opt.MapFrom(secList => secList.ForumId))
                    .ForMember(mainDto => mainDto.UserName,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.UserName));

            CreateMap<Section, BaseForumContainerInfoDto>()
                    .ForMember(mainDto => mainDto.NestedItemListInfo,
                            opt => opt.MapFrom(sec => Mapper.Map<IList<NestedContainerElementsInfoDto>>(sec.Topics)))
                    .ForMember(mainDto => mainDto.UserId,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.Id))
                    .ForMember(mainDto => mainDto.ParrentId,
                           opt => opt.MapFrom(secList => secList.SectionListId))
                    .ForMember(mainDto => mainDto.UserName,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.UserName));

            CreateMap<Post, LastUpdateTopicInfoDto>()
               .ForMember(x => x.Id, opt => opt.MapFrom(pt => pt.TopicId))
               .ForMember(x => x.Title, opt => opt.MapFrom(pt => pt.Topic.Title))

               .ForMember(mainDto => mainDto.UserId,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.Id))
               .ForMember(mainDto => mainDto.UserName,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.UserName))
               .ForMember(x => x.UpdateTime, opt => opt.MapFrom(pt => pt.DateUpdate));

            CreateMap<BaseForumContainerInfoDto, Forum>();

            #endregion


            #region TopicAndPostMapping

            CreateMap<UserAccount, UserPostInfoDto>()
               .ForMember(usProfile => usProfile.Image, opt => opt.MapFrom(acc => acc.UserProfile.Image))
               .ForMember(usProfile => usProfile.DateRegestration, opt => opt.MapFrom(acc => acc.UserProfile.DateRegistration))
               .ForMember(usProfile => usProfile.UserId, opt => opt.MapFrom(acc => acc.Id));
               
            CreateMap<Post, PostInfoDto>()
                .ForMember(x => x.UserPostInfo, opt => opt.MapFrom(x => x.User.UserAccount));


            CreateMap<Topic, TopicInfoDto>()
                .ForMember(topDto => topDto.PostDto, opt => opt.MapFrom(top => top.Posts))
                .ForMember(topDto => topDto.SectionId,
                           opt => opt.MapFrom(top => top.SectionId))
                .ForMember(mainDto => mainDto.UserId,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.Id))
                .ForMember(mainDto => mainDto.UserName,
                           opt => opt.MapFrom(forum => forum.User.UserAccount.UserName));


            #endregion

        }
    }
}
