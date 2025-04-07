namespace DesignPattern.Controllers.BehavioralPatterns.Command
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Command is a behavioral design pattern that turns a request into a stand-alone object that contains all information about the request.
    ///     This transformation lets you pass requests as a method arguments, delay or queue a request’s execution, and support undoable operations.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     Single Responsibility Principle. You can decouple classes that invoke operations from classes that perform these operations.
        ///     Open/Closed Principle.You can introduce new commands into the app without breaking existing client code.
        ///     You can implement undo/redo.
        ///     You can implement deferred execution of operations.
        ///     You can assemble a set of simple commands into a complex one.
        ///     
        /// Cons:
        ///     The code may become more complicated since you’re introducing a whole new layer between senders and receivers.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/command
        /// </summary>
        ///

        private readonly ICustomerHandler _customerHandler;

        public CommandController()
        {
            _customerHandler = new CustomerHandler();
        }

        /// <summary>
        /// Seperate business logic from controller
        ///     If handle more busniess logic, you only modify handler, not effect to controller
        /// </summary>
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerCommand customerCommand)
        {
            var result = _customerHandler.CreateCustomer(customerCommand);
            return Ok(result);
        }
    }
}
