namespace DesignPattern.Implement.Implement
{
    using DesignPattern.Implement.Interface;

    public class ProxyDocumentService : IProxyDocumentService
    {
        private readonly IDocumentService _realDocumentService;

        public ProxyDocumentService(IDocumentService documentService)
        {
            _realDocumentService = documentService;
        }

        public Guid Display()
        {
            // handle more logic here
            // cache, log, ...
            return _realDocumentService.Display();
        }
    }
}
