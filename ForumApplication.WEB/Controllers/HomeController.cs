using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumApplication.DataAccessLayer.DataContext;

namespace ForumApplication.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ForumContext con = new ForumContext();
            return View(con.Users.Find(3));
        }
    }
}