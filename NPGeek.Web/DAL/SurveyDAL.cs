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

        //public List<SurveyDAL> Get()
        //{
        //    List<ForumPost> postList = new List<ForumPost>();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand(@"select * from forum_post;", conn);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                ForumPost post = new ForumPost();

        //                post.Id = Convert.ToInt32(reader["id"]);
        //                post.Username = Convert.ToString(reader["username"]);
        //                post.Subject = Convert.ToString(reader["subject"]);
        //                post.Message = Convert.ToString(reader["message"]);
        //                post.PostDate = Convert.ToDateTime(reader["post_date"]);
        //                postList.Add(post);

        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }

        //    return postList;
        //}


        public bool SaveNewSurvey(SurveyModel survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @subject, @message, @post_date);", conn);
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