using AutoMapper;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.ServiceLayer.ApiService.Interfaces;
using ForumApplication.WEB.Attributes;
using ForumApplication.WEB.Models.PostViewModel;
using ForumApplication.WEB.Models.TopicViewModel;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ForumApplication.WEB.API.Controllers
{
    public class PostController : ApiController
    {
        IPostApiService _postService;

        public PostController(IPostApiService postService)
        {
            _postService = postService;
        }

        [ResponseType(typeof(PostInfoViewModel))]
        [ResponseType(typeof(string))]
        public IHttpActionResult Get()
        {
            var posts = _postService.GetAllElements();
            var postView = Mapper.Map<List<PostInfoViewModel>>(posts);
            return postView == null ? 
                (IHttpActionResult)BadRequest("No data") : Ok(postView);
        }

        [ResponseType(typeof(PostInfoViewModel))]
        [ResponseType(typeof(string))]
        public IHttpActionResult Get(int id)
        {
            var post = _postService.GetElement(id);
            var postView = Mapper.Map<PostInfoViewModel>(post);
            return postView == null ? 
                (IHttpActionResult) BadRequest("No data") : Ok(postView);
        }

        // POST: api/Values
        public void Post(CreatePostViewModel createpost)
        {
            var postDto = Mapper.Map<CreatePostDto>(createpost);
            _postService.CreateNewPost(postDto);
        }

        // PUT: api/Values/5
        public void Put(UpdatePostViewModel update)
        {
            var postUpdate = Mapper.Map<UpdatePostDto>(update);
            _postService.UpdatePost(postUpdate);
        }

        [ApiAuthorization]
        public void Delete(int id)
        {
            _postService.DeletePost(id);
        }
    }
}
