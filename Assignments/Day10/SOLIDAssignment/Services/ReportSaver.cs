using System.IO;

namespace SOLIDAssignment.Services
{
    public class ReportSaver
    {
        public void SaveToFile(string data)
        {
            File.WriteAllText("report.txt", data);
        }
    }
}