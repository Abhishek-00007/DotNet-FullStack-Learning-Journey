using SOLIDAssignment.Interfaces;

namespace SOLIDAssignment.Services
{
    public class ExcelFormatter : IFormatter
    {
        public string Format()
        {
            return "Formatting Report as Excel";
        }
    }
}