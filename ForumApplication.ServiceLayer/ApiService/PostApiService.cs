using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.ServiceLayer.ApiService.Interfaces;
using ForumApplication.ServiceLayer.PostService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer.ApiService
{
    public class PostApiService : PostService.PostService, IPostApiService
    {
        private IPostRepository _postRepo;
        public PostApiService(IPostRepository postRepo
            ,IPostRepository repository
            ,IUserProfileRepository userProfile) : 
                                    base(repository,userProfile)
        {
            _postRepo = postRepo;
        }
    }
}
