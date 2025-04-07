namespace DesignPattern.Controllers.BehavioralPatterns.TemplateMethod
{
    public interface IReportTemplateMethodExporter
    {
        void ExportReport();
    }

    public abstract class ReportTemplateMethodExporter : IReportTemplateMethodExporter
    {
        public void ExportReport()
        {
            var data = GetData();
            var formatted = FormatData(data);
            SaveToFile(formatted);
            LogExport();
        }

        protected abstract IEnumerable<string> GetData();
        protected abstract string FormatData(IEnumerable<string> data);

        protected abstract void SaveToFile(string formattedData);

        protected abstract void LogExport();
    }

    public interface ICsvReportExporter : IReportTemplateMethodExporter
    {
    }

    public interface IPdfReportExporter : IReportTemplateMethodExporter
    {
    }

    public class CsvReportExporter : ReportTemplateMethodExporter, ICsvReportExporter
    {
        protected override IEnumerable<string> GetData()
        {
            return new List<string> { "User1,Active", "User2,Inactive" };
        }

        protected override string FormatData(IEnumerable<string> data)
        {
            return string.Join("\n", data);
        }

        protected override void SaveToFile(string formattedData)
        {
            Console.WriteLine($"Saving as Csv: {formattedData}");
        }

        protected override void LogExport()
        {
            Console.WriteLine("Export as Csv logged.");
        }
    }

    public class PdfReportExporter : ReportTemplateMethodExporter, IPdfReportExporter
    {
        protected override IEnumerable<string> GetData()
        {
            return new List<string> { "User1 - Active", "User2 - Inactive" };
        }

        protected override string FormatData(IEnumerable<string> data)
        {
            return $"[PDF FORMAT]\n{string.Join("\n", data)}";
        }

        protected override void SaveToFile(string formattedData)
        {
            Console.WriteLine($"Saving as PDF: {formattedData}");
        }

        protected override void LogExport()
        {
            Console.WriteLine("Export as Pdf logged.");
        }
    }
}
