using Optional;

namespace Infrastructures.Implement.Services.ExportFiles
{
    public interface IExportFileService
    {
        public Option<MemoryStream, string> GenerateFile(string fullText);
    }
}
