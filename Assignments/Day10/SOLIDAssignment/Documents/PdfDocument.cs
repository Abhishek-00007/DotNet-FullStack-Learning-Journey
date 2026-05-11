using SOLIDAssignment.Interfaces;

namespace SOLIDAssignment.Documents
{
    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening PDF Document");
        }
    }
}