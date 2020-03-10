using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;

        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Park GetPark(string parkCode)
        {
            Park park = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkCode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        park = MapRowToParks(reader);
                    }
                }
                return park;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<Park> GetParks()
        {
            IList<Park> parks = new List<Park>(); 
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        parks.Add(MapRowToParks(reader));
                    }
                }
                return parks;
            }
            catch (SqlException e)
            {
                throw;
            }
        }

            private Park MapRowToParks(SqlDataReader reader)
            {
                return new Park()
                {
                    ParkCode = Convert.ToString(reader["parkCode"]),
                    ParkName = Convert.ToString(reader["parkName"]),
                    State = Convert.ToString(reader["state"]),
                    Acreage = Convert.ToInt32(reader["acreage"]),
                    ElevationFt = Convert.ToInt32(reader["elevationInFeet"]),
                    MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                    NumCampSites = Convert.ToInt32(reader["numberOfCampsites"]),
                    Climate = Convert.ToString(reader["climate"]),
                    YearFounded = Convert.ToInt32(reader["yearFounded"]),
                    AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                    InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                    QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                    ParkDescription = Convert.ToString(reader["parkDescription"]),
                    EntryFee = Convert.ToInt32(reader["entryFee"]),
                    NumAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]),
                };

            }
    }
}
