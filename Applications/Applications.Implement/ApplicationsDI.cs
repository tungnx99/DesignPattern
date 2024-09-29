using Applications.Implement.Interfaces.ConvertXMLToObject;
using Applications.Implement.Services.Configs;
using Applications.Implement.Services.ConvertXMLToObject;
using Applications.Implement.Services.ExportFiles;
using Infrastructures.Implement.Services.ExportFiles;
using Infrastructures.Share.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace Applications.Implement
{
    public static class ApplicationsDI
    {
        public static void Setup(IServiceCollection service)
        {
            service.AddKeyedScoped<IExportFileService, PDFFileService>(ExportFileConstant.Pdf);
            service.AddKeyedScoped<IExportFileService, PDFFileV2Service>(ExportFileConstant.PdfV2);

            service.AddScoped<IConvertXMLToObject, ConvertXMLToObject>();

            service.AddScoped<CloudConfigService>();
        }
    }
}
