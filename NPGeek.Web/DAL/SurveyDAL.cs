using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace NPGeek.Web.DAL
{
    public class SurveyDAL : ISurveyDAL
    {
        private string connectionString;
        public SurveyDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<FavoriteParksModel> GetFavoriteParks()
        {
            List<FavoriteParksModel> surveyList = new List<FavoriteParksModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select survey_result.parkCode, COUNT(survey_result.parkCode) as Total, parkName FROM survey_result JOIN park ON survey_result.parkCode = park.parkCode group by survey_result.parkCode, park.parkName order by Total desc;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        FavoriteParksModel surveyResults = new FavoriteParksModel();

                        surveyResults.ParkCode = Convert.ToString(reader["parkCode"]);
                        surveyResults.ParkName = Convert.ToString(reader["parkName"]);
                        surveyResults.Total = Convert.ToInt32(reader["Total"]);
                        surveyList.Add(surveyResults);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return surveyList;
        }


        public bool SaveNewSurvey(SurveyModel survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @email, @residenceState, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@email", survey.Email);
                    cmd.Parameters.AddWithValue("@residenceState", survey.ResidenceState);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
            }

            return true;
        }

    }
}