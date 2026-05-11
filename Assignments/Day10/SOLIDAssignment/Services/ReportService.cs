using SOLIDAssignment.Interfaces;

namespace SOLIDAssignment.Services
{
    public class ReportService
    {
        private readonly IReportFormatter _formatter;

        public ReportService(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Generate()
        {
            _formatter.Format();
        }
    }
}