using AutoMapper;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.ServiceLayer.PostService;
using ForumApplication.WEB.Models.PostViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumApplication.WEB.Controllers
{
    public class PostController : Controller
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePost(CreatePostViewModel createPostView)
        {
            var createPostDto = Mapper.Map<CreatePostDto>(createPostView);
            _postService.CreateNewPost(createPostDto);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}