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
        public ActionResult Forecast(string parkCode)
        {
            List<ForecastModel> forecast = dal.GetForecasts(parkCode);

            return View("Forecast", forecast);

        }
    }
}