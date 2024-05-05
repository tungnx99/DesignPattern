using Infrastructures.Implement.Services.ExportFiles;
using Infrastructures.Share.Extensions;
using Optional;

namespace Applications.Implement.Services.ExportFiles
{
    public class PDFFileService : IExportFileService
    {
        public virtual Option<MemoryStream, string> GenerateFile(string fullText)
        {
            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
            SelectPdf.PdfDocument doc = converter.ConvertHtmlString(fullText);

            // Save PDF to a memory stream
            var stream = new MemoryStream();
            doc.Save(stream);
            stream.Position = 0;
            return stream.ToOption();
        }
    }
}
