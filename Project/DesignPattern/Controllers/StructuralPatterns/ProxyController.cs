namespace DesignPattern.Controllers.StructuralPatterns
{
    using Microsoft.AspNetCore.Mvc;
    using DesignPattern.Implement.Interface;
    using DesignPattern.Implement.Implement;

    /// <summary>
    /// Proxy is a structural design pattern that lets you provide a substitute or placeholder for another object.
    ///     A proxy controls access to the original object, allowing you to perform something either before or
    ///     after the request gets through to the original object.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You can control the service object without clients knowing about it.
        ///     You can manage the lifecycle of the service object when clients don’t care about it.
        ///     The proxy works even if the service object isn’t ready or is not available.
        ///     Open/Closed Principle. You can introduce new proxies without changing the service or clients.
        ///     
        /// Cons:
        ///     The code may become more complicated since you need to introduce a lot of new classes.
        ///     The response from the service might get delayed.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/proxy
        /// </summary>
        ///

        private readonly IProxyDocumentService _proxyDocumentService;

        public ProxyController(IProxyDocumentService proxyDocumentService)
        {
            _proxyDocumentService = proxyDocumentService;
        }

        [HttpGet]
        public IActionResult GetDocument()
        {
            var document = _proxyDocumentService.Display();
            return Ok(document);
        }

        public static void Setup(IServiceCollection service)
        {
            service.AddSingleton<IDocumentService, RealDocumentService>();
            service.AddScoped<IProxyDocumentService, ProxyDocumentService>();
        }
    }
}
