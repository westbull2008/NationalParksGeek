using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class FavoriteParksModel
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public int Total { get; set; }
		public string ParkDescription { get; set; }
    }
}