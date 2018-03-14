using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace NPGeek.Web.DAL
{
    public class ParkDAL : IParkDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public ParkDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public List<ParkModel> GetAllParks()
        {
            List<ParkModel> parks = new List<ParkModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ParkModel park = new ParkModel();

                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.Name = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        parks.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return parks;

        }

		public ParkModel GetParkDetail(string parkCode)
		{
			ParkModel park = new ParkModel();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkCode = @parkCode;", conn);
					cmd.Parameters.AddWithValue("@parkCode", parkCode);
					
					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{ 
						park.ParkCode = Convert.ToString(reader["parkCode"]);
						park.Name = Convert.ToString(reader["parkName"]);
						park.State = Convert.ToString(reader["state"]);
						park.Acreage = Convert.ToInt32(reader["acreage"]);
						park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
						park.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
						park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
						park.Climate = Convert.ToString(reader["climate"]);
						park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
						park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
						park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
						park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
						park.ParkDescription = Convert.ToString(reader["parkDescription"]);
						park.EntryFee = Convert.ToInt32(reader["entryFee"]);
						park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

					}
				}


			}
			catch(SqlException ex)
			{
				throw ex;
			}

			return park;
		}

    }
}