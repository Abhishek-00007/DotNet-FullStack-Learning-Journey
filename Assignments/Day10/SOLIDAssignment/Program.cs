using SOLIDAssignment.Services;
using SOLIDAssignment.Models;
using SOLIDAssignment.Factory;
using SOLIDAssignment.Interfaces;

namespace SOLIDAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SRP Example");

            ReportGenerator generator = new ReportGenerator();

            string report = generator.GenerateReport();

            ReportSaver saver = new ReportSaver();

            saver.SaveToFile(report);

            Console.WriteLine(report);

            Console.WriteLine();


            Console.WriteLine("OCP Example");

            IFormatter pdfFormatter = new PdfFormatter();

            ReportFormatter formatter = new ReportFormatter(pdfFormatter);

            formatter.Display();

            Console.WriteLine();


            Console.WriteLine("LSP Example");

            Report salesReport = new SalesReport();

            salesReport.Generate();

            Console.WriteLine();


            Console.WriteLine("ISP Example");

            SimpleReport simpleReport = new SimpleReport();

            simpleReport.Generate();

            Console.WriteLine();


            Console.WriteLine("DIP Example");

            IReportFormatter reportFormatter = new PdfFormatter();

            ReportService reportService = new ReportService(reportFormatter);

            reportService.Generate();

            Console.WriteLine();


            Console.WriteLine("Factory Pattern Example");

            IDocument pdf = DocumentFactory.CreateDocument("PDF");

            pdf.Open();

            IDocument word = DocumentFactory.CreateDocument("WORD");

            word.Open();
        }
    }
}