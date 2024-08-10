using DesignPattern.Implement.Interface;
using DesignPattern.Model.Models.Items;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers.CreationalPatterns
{
    /// <summary>
    /// Builder is a creational design pattern that lets you construct complex objects step by step.
    /// The pattern allows you to produce different types and representations of an object using the same construction code.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BuilderController : ControllerBase
    {
        /// <summary>
        /// Pros:
        /// You can construct objects step-by-step, defer construction steps or run steps recursively.
        /// You can reuse the same construction code when building various representations of products.
        /// Single Responsibility Principle.You can isolate complex construction code from the business logic of the product.
        /// 
        /// Cons:
        /// The overall complexity of the code increases since the pattern requires creating multiple new classes.
        /// 
        /// Reference:
        ///     https://refactoring.guru/design-patterns/builder
        /// </summary>
        /// 

        private readonly IProductService<HomeRequest> _homeService;

        public BuilderController(IProductService<HomeRequest> homeService)
        {
            _homeService = homeService;
        }

        [HttpPost]
        public IActionResult CaculateProductPrice(HomeRequest homeRequest)
        {
            return Ok(_homeService.CaculateProductPrice(homeRequest));
        }

        [HttpPost]
        public IActionResult Payment(List<TicketUpdateRequest> ticketUpdates)
        {
            return Ok(_homeService.PaymentProduct(ticketUpdates));
        }

        [HttpGet]
        public IActionResult OrderStatus(Guid id)
        {
            return Ok(_homeService.OrderStatus(id));
        }
    }
}
