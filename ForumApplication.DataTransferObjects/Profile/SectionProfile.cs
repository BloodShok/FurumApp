using AutoMapper;
using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class SectionProfile : AutoMapper.Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionDto>()
                .ForMember(secDto => secDto.CountOfPosts, opt => opt.MapFrom(sec => CountOfPosts(sec)))
                .ForMember(secDto => secDto.CountOfTopics, opt => opt.MapFrom(sec => CountOfTopics(sec)))
                .ForMember(secDto => secDto.UserName, opt => opt.MapFrom(sec => sec.User.Login))
                .ForMember(secDto => secDto.NestedTopicListInfo, opt =>
                                            opt.MapFrom(sec => Mapper.Map<IList<NestedTopicItemsInfoDto>>(sec.Topics)));
        }

        private static int CountOfPosts(Section SectionBase)
        {
            int sumofPosts = 0;

            SectionBase.Topics
                    .ForEach(posts => sumofPosts += posts.Posts.Count);

            return sumofPosts;
        }
        private static int CountOfTopics(Section SectionBase)
        {
            return SectionBase.Topics.Count;
        }
    }
}
