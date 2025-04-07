namespace DesignPattern.Controllers.BehavioralPatterns.State
{
    using Microsoft.AspNetCore.Mvc;
    using System.Reflection.PortableExecutable;

    /// <summary>
    /// State is a behavioral design pattern that lets an object alter its behavior when its internal state changes.
    ///     It appears as if the object changed its class.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        /// <summary>
        /// 
        /// Pros:
        ///     Single Responsibility Principle. Organize the code related to particular states into separate classes.
        ///     Open/Closed Principle.Introduce new states without changing existing state classes or the context.
        ///     Simplify the code of the context by eliminating bulky state machine conditionals.
        ///     
        /// Cons:
        ///     Applying the pattern can be overkill if a state machine has only a few states or rarely changes.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/state
        /// </summary>

        /// Real application, this design pattern is always used to Manage state of CRUD processing.
        /// In business applications, this design pattern will use for example:

        private readonly OrderContext _orderContext;

        public StateController(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        [HttpPost("process")]
        public IActionResult ProcessOrder()
        {
            _orderContext.ProcessOrder();
            return Ok("Order processed successfully. Current order status: " + _orderContext.GetState());
        }

        [HttpPost("cancel")]
        public IActionResult CancelOrder()
        {
            _orderContext.SetState(new CancelledState());
            _orderContext.ProcessOrder();
            return Ok("Order processed successfully. Current order status: " + _orderContext.GetState());
        }

        [HttpGet("status")]
        public IActionResult GetOrderStatus()
        {
            return Ok("Current order status: " + _orderContext.GetState());
        }

        public static void Setup(IServiceCollection services)
        {
            services.AddSingleton<OrderContext>();
            services.AddSingleton<IOrderState, ProcessingState>();
        }
    }
}
