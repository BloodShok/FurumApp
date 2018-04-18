using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataTransferObjects;

namespace ForumApplication.ServiceLayer.PostService
{
    public class PostService : IPostService
    {
        IPostRepository _repo;
        public PostService(IPostRepository repository)
        {
            _repo = repository;
        }
        public IList<PostDto> GetAllElements()
        {
            var PostList = _repo.GetAllIncludeReferences();

            return Mapper.Map<List<PostDto>>(PostList);
        }

        public PostDto GetElement(int id)
        {
            var Post = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<PostDto>(Post);
        }
    }
}
