using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;

namespace NPGeek.Web.Controllers
{
    public class HomeController : Controller
    {
		IParkDAL dal;

		public HomeController(IParkDAL dal)
		{
			this.dal = dal;
		}

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

		public ActionResult Survey()
		{
			return View();
		}
    }
}