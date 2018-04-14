using System;
using ForumApplication.DataAccessLayer.DataContext;
using ForumApplication.DataLayer.ProfileDtoModels.Mapper;
using ForumApplication.DataLayer.ProfileDtoModels.QueryObjects;
using ForumApplication.DataLayer.Repository;
using ForumApplication.DataLayer.Repository.CustomRepository;
using ForumApplication.Domain.Entitys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForumApplication.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ForumRepository repo = new ForumRepository(new ForumContext());

            var item = repo.GetAllIncludeReferences();

            ForumDto fdt = new ForumDtoMapper().SelectForumDto(item[2]);

            Console.WriteLine($"Id: {fdt.Id} \n Title: {fdt.Title}\n " +
                $" DataC : {fdt.DateCreated}\n" +
                $" DataU: {fdt.DateUpdate}\n" +
                $" UserId: {fdt.UserId}\n" +
                $" Coll of posts: {fdt.CountOfPosts} \n" +
                $" Coll of topics: {fdt.CountOfTopics}");
        }
    }
}
