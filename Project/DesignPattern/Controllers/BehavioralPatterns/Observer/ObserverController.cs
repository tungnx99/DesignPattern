namespace DesignPattern.Controllers.BehavioralPatterns.Observer
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Observer is a behavioral design pattern that lets you define a subscription mechanism to allow multiple objects to listen and react to events or changes in another object.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ObserverController : ControllerBase
    {
        /// <summary>
        /// 
        /// Pros:
        ///     Open/Closed Principle. You can introduce new subscriber classes without having to change the publisher’s code (and vice versa if there’s a publisher interface).
        ///     You can establish relations between objects at runtime.
        ///     
        /// Cons:
        ///     Subscribers are notified in random order.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/observer
        /// </summary>

        private readonly IOrderObserver _orderObserver;

        public ObserverController(IOrderObserver orderObserver)
        {
            _orderObserver = orderObserver;
        }

        [HttpPost]
        public IActionResult NotificationWithStatusCode(SenderDataModel model)
        {
            var result = _orderObserver.OnSenderOrderStatusChanged(model);

            return Ok(result);
        }

        public static void Setup(IServiceCollection services)
        {
            services.AddSingleton<IOrderObserver, OrderObserver>();
            services.AddSingleton<IOrderNotifier, OrderNotifier>();
            services.AddSingleton<IEmailNotificationService, EmailNotificationService>();
            services.AddSingleton<ISmsNotificationService, SmsNotificationService>();
        }
    }
}
