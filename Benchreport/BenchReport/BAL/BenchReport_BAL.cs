using BenchReport.BO;
using BenchReport.DAL;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace BenchReport.BAL
{
    public class BenchReportBAL
    {

        //Make the data accessable in key value pair
        private readonly BenchReportDAL benchReportDAL;

        public BenchReportBAL()
        {
            benchReportDAL = new BenchReportDAL();
        }
        //To get the Values
        public List<BenchReportBO> GetBenchReportValue()
        {
            DataTable dt = benchReportDAL.GetBenchReport();

            List<BenchReportBO> BenchReportValues =
                new List<BenchReportBO>();

            foreach (DataRow row in dt.Rows)
            {
                BenchReportBO BenchReportValue = new BenchReportBO();

                BenchReportValue.EmployeeId =
                    Convert.ToInt32(row["EmployeeId"]);

                BenchReportValue.EmployeeName =
                    row["EmployeeName"].ToString();

                BenchReportValue.Department =
                    row["Department"].ToString();

                BenchReportValue.Email =
                    row["Email"].ToString();

                BenchReportValue.Salary =
                    Convert.ToDecimal(row["Salary"]);

                BenchReportValues.Add(BenchReportValue);
            }

            return BenchReportValues;
        }


        //mail Body
        public string CreateMailBody(List<BenchReportBO> BenchReportValues)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<html>");
            html.Append("<body>");

            html.Append("<h2>Employee Report</h2>");

            html.Append("<table border='1' cellpadding='8' cellspacing='0'>");

            html.Append("<tr>");
            html.Append("<th>Employee ID</th>");
            html.Append("<th>Name</th>");
            html.Append("<th>Department</th>");
            html.Append("<th>Email</th>");
            html.Append("<th>Salary</th>");
            html.Append("</tr>");

            foreach (BenchReportBO BenchReportValue in BenchReportValues)
            {
                html.Append("<tr>");

                html.Append("<td>");
                html.Append(BenchReportValue.EmployeeId);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(BenchReportValue.EmployeeName);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(BenchReportValue.Department);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(BenchReportValue.Email);
                html.Append("</td>");

                html.Append("<td>");
                html.Append(BenchReportValue.Salary);
                html.Append("</td>");

                html.Append("</tr>");
            }

            html.Append("</table>");

            html.Append("</body>");
            html.Append("</html>");

            return html.ToString();
        }


        //To Send a mail

        public void SendEmail(string mailBody)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("sender@company.com");

            mail.To.Add("manager@company.com");

            mail.Subject = "Employee Report";

            mail.Body = mailBody;

            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.company.com");

            smtp.Port = 587;

            smtp.EnableSsl = true;

            smtp.Credentials =
                new NetworkCredential(
                    "sender@company.com",
                    "password");

            smtp.Send(mail);
        }




    }
}