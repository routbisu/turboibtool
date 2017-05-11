using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_QA_Tools
{
    public class BusinessLogic
    {
        string connectionString = "";
        SqlConnection connection = null;

        public BusinessLogic()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TurboIB"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public DataSet GetInstalmentSchedule(string policyNumber)
        {

        }
    }
}
