using AutoMapper;
using ForumApplication.DataLayer.ProfileDtoModels.QueryObjects;
using ForumApplication.ServiceLayer.ForumService;
using ForumApplication.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ForumApplication.WEB.Controllers
{
    public class HomeController : Controller
    {
        DbContext _context;
        public HomeController(DbContext context)
        {
            _context = context;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            ConcretForumDto dorumDto = new ConcretForumDto(_context);

            var item = Mapper.Map<ForumDto, ForumViewModel>(dorumDto.SelectForumDto(id));

            return View("Forum",item);
        }
    }
}