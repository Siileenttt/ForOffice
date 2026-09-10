using BenchReport.BAL;
using BenchReport.BO;

namespace BenchReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create bal object
            BenchReportBAL bal = new BenchReportBAL();

            //get the required value
            List<BenchReportBO> benchReportValue =bal.GetBenchReportValue();

            //create mail body
            string createMailBody = bal.CreateMailBody(benchReportValue);

            //send mail
            bal.SendEmail(createMailBody);

        }
    }
}
