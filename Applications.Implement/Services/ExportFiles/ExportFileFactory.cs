using Infrastructures.Implement.Services.ExportFiles;
using Infrastructures.Share.Enums;

namespace Applications.Implement.Services.ExportFiles
{
    public static class ExportFileFactory
    {
        public static IExportFileService CreateInstance(ExportFileType fileType)
        {
            switch (fileType)
            {
                case ExportFileType.Document:
                    {
                        throw new NotImplementedException();
                    }
                case ExportFileType.PDF:
                    {
                        return new PDFFileService();
                    }
                case ExportFileType.Excel:
                    {
                        throw new NotImplementedException();
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }
    }
}
