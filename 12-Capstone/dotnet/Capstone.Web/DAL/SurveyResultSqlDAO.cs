using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyResultSqlDAO : ISurveyResultDAO
    {
        private string connectionString;

        public SurveyResultSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void SubmitSurvey(SurveyModel survey)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into survey_result VALUES(@parkCode, @emailAddress, @state, @activityLevel)", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<SurveyResultsModel> GetPopularParks()
        {
            List<SurveyResultsModel> surveyResults = new List<SurveyResultsModel>();
           

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT park.parkCode, park.parkName, COUNT(park.parkCode) AS park_count FROM park
                                                  JOIN survey_result ON park.parkCode = survey_result.parkCode
                                                  GROUP BY park.parkCode, park.parkName
                                                  ORDER BY park_count DESC, park.parkName ASC", conn);


                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        SurveyResultsModel surveyResultsModel = new SurveyResultsModel();
                        surveyResultsModel.ParkCode = Convert.ToString(reader["parkCode"]);
                        surveyResultsModel.ParkName = Convert.ToString(reader["parkName"]);
                        surveyResultsModel.ReviewCount = Convert.ToInt32(reader["park_count"]);

                        surveyResults.Add(surveyResultsModel);
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

            return surveyResults;
        }




    }
}
