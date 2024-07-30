using Applications.Implement.Services.ExportFiles;
using Infrastructures.Implement.Services.ExportFiles;
using Infrastructures.Share.Constants;
using Infrastructures.Share.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers.CreationalPatterns
{
    /// <summary>
    /// Other name is Virtual Constructor
    /// Factory Method is a creational design pattern that provides an interface for creating objects in a superclass,
    /// but allows subclasses to alter the type of objects that will be created.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FactoryMethodController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You avoid tight coupling between the creator and the concrete products.
        ///     Single Responsibility Principle.You can move the product creation code into one place in the program, making the code easier to support.
        ///     Open/Closed Principle.You can introduce new types of products into the program without breaking existing client code.
        /// 
        /// Cons:
        ///     The code may become more complicated since you need to introduce a lot of new subclasses to implement the pattern.
        ///     The best case scenario is when you’re introducing the pattern into an existing hierarchy of creator classes.
        ///     
        /// Referance:
        ///     https://refactoring.guru/design-patterns/factory-method
        ///     https://www.bensampica.com/post/keyedservices/
        /// </summary>
        private readonly IExportFileService _exportPdfFile;
        private readonly IExportFileService _exportPdfFileV2;

        public FactoryMethodController(
            [FromKeyedServices(ExportFileConstant.Pdf)] IExportFileService exportPdfFile,
            [FromKeyedServices(ExportFileConstant.PdfV2)] IExportFileService exportPdfFileV2)
        {
            _exportPdfFile=exportPdfFile;
            _exportPdfFileV2=exportPdfFileV2;
        }

        /// <summary>
        /// Not using Dependency Injection
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ExportPdf()
        {
            var result = ExportFileFactory.CreateInstance(ExportFileType.PDF).GenerateFile(string.Empty);

            return result.Match<IActionResult>(some: stream => File(stream, "Export Pdf Name"),
              none: BadRequest);
        }

        /// <summary>
        /// Using Dependency Injection support by Dot Net 8
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ExportPdfNet8()
        {
            var result = _exportPdfFile.GenerateFile(string.Empty);

            return result.Match<IActionResult>(some: stream => File(stream, "Export Pdf Name"),
              none: BadRequest);
        }

        /// <summary>
        /// You also use Factory Method Pattern for other suitable bussiness
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ExportPdfV2Net8()
        {
            var result = _exportPdfFileV2.GenerateFile(string.Empty);

            return result.Match<IActionResult>(some: stream => File(stream, "Export Pdf Name"),
              none: BadRequest);
        }
    }
}
