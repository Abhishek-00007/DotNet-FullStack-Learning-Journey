using SOLIDAssignment.Interfaces;

namespace SOLIDAssignment.Models
{
    public class SimpleReport : IGenerateReport
    {
        public void Generate()
        {
            Console.WriteLine("Simple Report Generated");
        }
    }
}