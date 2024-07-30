using Optional;

namespace Applications.Implement.Services.ExportFiles
{
    public class PDFFileV2Service : PDFFileService
    {
        public override Option<MemoryStream, string> GenerateFile(string fullText)
        {
            throw new NotSupportedException();
        }
    }
}
