using SOLIDAssignment.Interfaces;

namespace SOLIDAssignment.Services
{
    public class PdfFormatter : IFormatter, IReportFormatter
    {
        public string Format()
        {
            return "Formatting Report as PDF";
        }

        void IReportFormatter.Format()
        {
            Console.WriteLine("PDF Formatting Done");
        }
    }
}