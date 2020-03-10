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

        public Park GetPark()
        {
            throw new NotImplementedException();
        }

        public IList<Park> GetParks()
        {
            try
            {

            }
            catch (SqlException e)
            {

                throw;
            }
        }
    }
}
