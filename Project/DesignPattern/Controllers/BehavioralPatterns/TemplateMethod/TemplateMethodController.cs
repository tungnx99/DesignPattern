namespace DesignPattern.Controllers.BehavioralPatterns.TemplateMethod
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Template Method is a behavioral design pattern that defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps of the algorithm without changing its structure.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TemplateMethodController : ControllerBase
    {
        /// <summary>
        /// 
        /// Pros:
        ///     You can let clients override only certain parts of a large algorithm, making them less affected by changes that happen to other parts of the algorithm.
        ///     You can pull the duplicate code into a superclass.
        ///     
        /// Cons:
        ///     Some clients may be limited by the provided skeleton of an algorithm.
        ///     You might violate the Liskov Substitution Principle by suppressing a default step implementation via a subclass.
        ///     Template methods tend to be harder to maintain the more steps they have.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/template-method
        /// </summary>

        private readonly ICsvReportExporter _csvReportExporter;
        private readonly IPdfReportExporter _pdfReportExporter;

        public TemplateMethodController(ICsvReportExporter csvReportExporter, IPdfReportExporter pdfReportExporter)
        {
            _csvReportExporter = csvReportExporter;
            _pdfReportExporter = pdfReportExporter;
        }

        [HttpPost]
        public IActionResult ExportCsvReport()
        {
            _csvReportExporter.ExportReport();
            return Ok("CSV report exported successfully.");
        }

        [HttpPost]
        public IActionResult ExportPdfReport()
        {
            _pdfReportExporter.ExportReport();
            return Ok("PDF report exported successfully.");
        }

        public static void Setup(IServiceCollection services)
        {
            services.AddSingleton<ICsvReportExporter, CsvReportExporter>();
            services.AddSingleton<IPdfReportExporter, PdfReportExporter>();
        }
    }
}
