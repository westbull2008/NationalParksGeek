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

            return View("ForecastFarenheit", forecast);

        }

		public ActionResult ForecastCelsius (string parkCode)
		{
			List<ForecastModel> forecast = dal.GetForecasts(parkCode);

			return View("ForecastCelsius", forecast);
		}
    }
}