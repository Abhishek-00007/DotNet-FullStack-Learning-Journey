using SOLIDAssignment.Interfaces;

namespace SOLIDAssignment.Services
{
    public class ReportFormatter
    {
        private readonly IFormatter _formatter;

        public ReportFormatter(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Display()
        {
            Console.WriteLine(_formatter.Format());
        }
    }
}