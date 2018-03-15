using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;
using NPGeek.Web.Models;


namespace NPGeek.Web.Controllers
{
	public class ForecastController : Controller
	{

		IForecastDAL dal;

		public ForecastController(IForecastDAL dal)
		{
			this.dal = dal;
		}
		public ActionResult ForecastFarenheit(string parkCode)
		{
			List<ForecastModel> forecast = dal.GetForecasts(parkCode);

			return PartialView("ForecastFarenheit", forecast);

		}

		public ActionResult ForecastCelsius(string parkCode)
		{
			List<ForecastModel> forecast = dal.GetForecasts(parkCode);

			return PartialView("ForecastCelsius", forecast);
		}

		//private TempPreference GetPreference()
		//{
		//	TempPreference preference = null;

		//	// See if the user has a shopping cart stored in session
		//	if (Session["Temp_Preference"] == null)
		//	{
		//		preference = new TempPreference();
		//		Session["Temp_Preference"] = preference; // <-- saves the shopping cart into session
		//	}
		//	else
		//	{
		//		preference = Session["Temp_Preference"] as TempPreference; // <-- gets the shopping cart out of session
		//	}

		//	// If not, create one for them


		//	return preference;

		//}
	}

}