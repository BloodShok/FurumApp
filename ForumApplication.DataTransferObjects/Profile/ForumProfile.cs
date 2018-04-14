using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.DataTransferObjects.Profile
{
   public class ForumProfile : AutoMapper.Profile
    {
        public ForumProfile()
        {
            CreateMap<Forum, ForumDto>()
                .ForMember("UserName", opt => opt.MapFrom(forum => forum.User.Login))
                .ForMember("CountOfPosts", opt => opt.MapFrom(forum => CountOfPosts(forum)))
                .ForMember("CountOfTopics", opt => opt.MapFrom(forum => CountOfTopics(forum)));
        }

        private static int CountOfPosts(Forum ForumBase)
        {
            int sumofPosts = 0;

            ForumBase.SectionLists
            .ForEach(section => section.Sections
                .ForEach(topics => topics.Topics
                    .ForEach(posts => sumofPosts += posts.Posts.Count)));

            return sumofPosts;
        }
        private static int CountOfTopics(Forum ForumBase)
        {
            int sumofPosts = 0;

            ForumBase.SectionLists
            .ForEach(section => section.Sections
                .ForEach(topics => sumofPosts += topics.Topics.Count));

            return sumofPosts;
        }
    }
    
}
