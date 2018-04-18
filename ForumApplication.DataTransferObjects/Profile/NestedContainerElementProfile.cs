using ForumApplication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects.Profile
{
    public class NestedContainerElementProfile : AutoMapper.Profile
    {
        public NestedContainerElementProfile()
        {
            CreateMap<SectionList, NestedContainerElement>();

            CreateMap<Section, NestedContainerElement>()
                .ForMember(section => section.CountOfTopics,
                                    opt => opt.MapFrom(section => CountOfTopics(section)))
                .ForMember(section => section.CountOfPosts,
                                    opt => opt.MapFrom(section => CountOfPosts(section)));

            CreateMap<Topic, NestedContainerElement>()
                .ForMember(topic => topic.CountOfPosts,
                                    opt => opt.MapFrom(topic => topic.Posts.Count))
                .ForMember(topic => topic.CountOfTopics, opt => opt.MapFrom(x => 0));
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
