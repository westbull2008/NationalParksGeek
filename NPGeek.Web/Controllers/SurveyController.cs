using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;
using NPGeek.Web.Models;

namespace NPGeek.Web.Controllers
{
    public class SurveyController : Controller
    {
        ISurveyDAL dal;

        public SurveyController (ISurveyDAL dal)
        {
            this.dal = dal;
        }

        // GET: Survey
        public ActionResult Survey()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FavoriteParks(SurveyModel model)
        {
            bool result = dal.SaveNewSurvey(model);
            return View();
        }
    }
}