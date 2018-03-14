using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;
using NPGeek.Web.Models;

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
            List<ParkModel> parks = dal.GetAllParks();
            return View("Index", parks);
        }

		public ActionResult Detail(string parkCode)
		{
			ParkModel park = dal.GetParkDetail(parkCode);

			return View("Detail", park);
		}
        
		public ActionResult Survey()
		{
			return View();
		}
    }
}