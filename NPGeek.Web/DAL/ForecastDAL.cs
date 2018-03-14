using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace NPGeek.Web.DAL
{
    public class ForecastDAL : IForecastDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public ForecastDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public List<ForecastModel> GetForecasts(string parkCode)
        {
            List<ForecastModel> forecasts = new List<ForecastModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode; ", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ForecastModel forecast = new ForecastModel();

                        forecast.ParkCode = Convert.ToString(reader["parkCode"]);
                        forecast.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        forecast.Low = Convert.ToInt32(reader["low"]);
                        forecast.High = Convert.ToInt32(reader["high"]);
                        forecast.Forecast = Convert.ToString(reader["forecast"]);

                        forecasts.Add(forecast);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return forecasts;

        }

    }
}