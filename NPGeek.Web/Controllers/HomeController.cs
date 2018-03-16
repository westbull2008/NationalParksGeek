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
			Session["TempChoice"] = GetTempChoice();
			return View("Index", parks);
		}

		public ActionResult Detail(string parkCode)
		{
			ParkModel park = dal.GetParkDetail(parkCode);

			return View("Detail", park);
		}

		public ActionResult DetailCelsius(string parkCode)
		{
			ParkModel park = dal.GetParkDetail(parkCode);

			return View("DetailCelsius", park);
		}

		[HttpPost]
		public ActionResult Detail(string parkCode, string tempChoice)
		{
		
			Session["TempChoice"] = tempChoice;
			
			return RedirectToAction("Detail", new { parkCode = parkCode });
		}

		public string GetTempChoice()
		{
			string tempChoice = "";
			if (Session["TempChoice"] == null)
			{
				Session["TempChoice"] = "F";
			}
			else
			{
				tempChoice = Session["TempChoice"] as string;
			}
			return tempChoice;
		}

		public ActionResult Webcams()
		{
			return View();
		}
	}
}