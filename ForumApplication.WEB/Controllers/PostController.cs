using AutoMapper;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.ServiceLayer.PostService;
using ForumApplication.WEB.Models.PostViewModel;
using ForumApplication.WEB.Models.TopicViewModel;
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
            var validationText = createPostView.MessageStringContent.Replace("script", "scriрt");
            var createPostDto = Mapper.Map<CreatePostDto>(createPostView);
            createPostDto.MessageStringContent = validationText; 
            _postService.CreateNewPost(createPostDto);
            return Redirect(Request.UrlReferrer.ToString());
        }


        [HttpGet]
        public ActionResult Update(int Id)
        {
            var postDto = _postService.GetPostForUpdate(Id);
            var postViewModel = Mapper.Map<UpdatePostViewModel>(postDto);
            return View(postViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Update(UpdatePostViewModel modelForUpdate)
        {
            var validationText = modelForUpdate.MessageStringContent.Replace("script>", "text>");
            var postDto = Mapper.Map<UpdatePostDto>(modelForUpdate);

            postDto.MessageStringContent = validationText;
            _postService.UpdatePost(postDto);
            var topicId = _postService.GetTopicIdByPostId(modelForUpdate.PostId);

            return RedirectToAction("Item", "Topic", new { Id = topicId });
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Moderator")]
        public ActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}