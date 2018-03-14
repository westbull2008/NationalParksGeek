using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.DAL;
using System.Data.SqlClient;
using System.Configuration;

namespace NPGeek.Web.Models
{
    public class SurveyModel
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string Email { get; set; }
        public string ResidenceState { get; set; }
        public string ActivityLevel { get; set; }
        //public List<ParkModel> ParkList
        //{
        //    get
        //    {
        //        ParkDAL dal = new ParkDAL(connectionString);
        //        ParkList = dal.GetAllParks();

        //        return ParkList;
        //    }
        //    set
        //    {

        //    }
        //}
        //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}