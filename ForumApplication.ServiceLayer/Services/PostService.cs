using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;
using ForumApplication.DataTransferObjects.PostDto;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.ServiceLayer.PostService
{
    public class PostService : IPostService
    {
        IPostRepository _postRepo;
        IUserProfileRepository _profileRepo;
        public PostService(IPostRepository repository, IUserProfileRepository userProfile)
        {
            _postRepo = repository;
            _profileRepo = userProfile;
        }

        public void CreateNewPost(CreatePostDto createPostDto)
        {
            var postItem = Mapper.Map<Post>(createPostDto);
            postItem.UserId = _profileRepo.GetProfileIdByAccountId(createPostDto.UserId);

            _postRepo.AddNewItem(postItem);
            _postRepo.SaveChanges();
        }

        public void DeletePost(int id)
        {
            _postRepo.DeleteItemById(id);
            _postRepo.SaveChanges();
        }

        public IList<PostInfoDto> GetAllElements()
        {
            var PostList = _postRepo.GetAllIncludeReferences();

            return Mapper.Map<List<PostInfoDto>>(PostList);
        }

        public PostInfoDto GetElement(int id)
        {
            var Post = _postRepo.GetByIDIncludeReferences(id);

            return Mapper.Map<PostInfoDto>(Post);
        }

        public UpdatePostDto GetPostForUpdate(int id)
        {
            var postForUpdate = _postRepo.GetByID(id);

            return Mapper.Map<UpdatePostDto>(postForUpdate);
        }

        public int GetTopicIdByPostId(int postId)
        {
            return _postRepo.GetTopicId(postId);
        }

        public void UpdatePost(UpdatePostDto postDto)
        {
            _postRepo.Update(postDto);
            _postRepo.SaveChanges();
        }
    }
}
