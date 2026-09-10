using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BenchReport.DAL
{
    public class BenchReportDAL
    {
        //uat
        private readonly string connectionString = "Server=YOUR_SERVER;Database=EmployeeDb;Trusted_Connection=True;TrustServerCertificate=True;";
        ////preprod
        //private readonly string connectionString = "Server=YOUR_SERVER;Database=EmployeeDb;Trusted_Connection=True;TrustServerCertificate=True;";
        ////prod
        //private readonly string connectionString = "Server=YOUR_SERVER;Database=EmployeeDb;Trusted_Connection=True;TrustServerCertificate=True;";

       
        public DataTable GetBenchReport()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                       new SqlCommand("GetEmployeeReport", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
