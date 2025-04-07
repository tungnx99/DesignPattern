namespace DesignPattern.Controllers.BehavioralPatterns.Mediator
{
    using Microsoft.AspNetCore.Mvc;
    using static DesignPattern.Controllers.StructuralPatterns.FlyweightController;

    /// <summary>
    /// Mediator is a behavioral design pattern that lets you reduce chaotic dependencies between objects.
    ///     The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MediatorController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     Single Responsibility Principle. You can extract the communications between various components into a single place, making it easier to comprehend and maintain.
        ///     Open/Closed Principle.You can introduce new mediators without having to change the actual components.
        ///     You can reduce coupling between various components of a program.
        ///     You can reuse individual components more easily.
        ///     
        /// Cons:
        ///     Over time a mediator can evolve into a God Object.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/mediator
        /// </summary>

        private readonly ICreateOrderMediatorHandler _createOrderMediatorHandler;

        public MediatorController(ICreateOrderMediatorHandler createOrderMediatorHandler)
        {
            _createOrderMediatorHandler = createOrderMediatorHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand createOrder)
        {
            var result = await _createOrderMediatorHandler.Handle(createOrder);

            return Ok(result);
        }

        public static void Setup(IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IInventoryService, InventoryService>();
            services.AddSingleton<ICreateOrderMediatorHandler, CreateOrderMediatorHandler>();
        }
    }
}
