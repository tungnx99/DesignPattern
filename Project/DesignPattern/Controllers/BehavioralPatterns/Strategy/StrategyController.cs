namespace DesignPattern.Controllers.BehavioralPatterns.Strategy
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Cryptography;

    /// <summary>
    /// Strategy is a behavioral design pattern that lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StrategyController : ControllerBase
    {
        /// <summary>
        /// 
        /// Pros:
        ///     You can swap algorithms used inside an object at runtime.
        ///     You can isolate the implementation details of an algorithm from the code that uses it.
        ///     You can replace inheritance with composition.
        ///     Open/Closed Principle. You can introduce new strategies without having to change the context.
        ///     
        /// Cons:
        ///     If you only have a couple of algorithms and they rarely change, there’s no real reason to overcomplicate the program with new classes and interfaces that come along with the pattern.
        ///     Clients must be aware of the differences between strategies to be able to select a proper one.
        ///     A lot of modern programming languages have functional type support that lets you implement different versions of an algorithm inside a set of anonymous functions.
        ///         Then you could use these functions exactly as you’d have used the strategy objects, but without bloating your code with extra classes and interfaces.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/strategy
        /// </summary>

        private readonly IShippingStrategyFactory _strategyFactory;

        public StrategyController(IShippingStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        [HttpGet("calculate")]
        public IActionResult CalculateShipping([FromQuery] CustomerType customerType, [FromQuery] decimal orderAmount)
        {
            try
            {
                var strategy = _strategyFactory.GetStrategy(customerType);
                var fee = strategy.CalculateShippingFee(orderAmount);
                return Ok(new { ShippingFee = fee });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<RegularCustomerShipping>();
            services.AddScoped<VipCustomerShipping>();
            services.AddScoped<BusinessCustomerShipping>();


            services.AddScoped<IShippingStrategyFactory>(sp =>
            {
                var strategies = new List<IShippingStrategy>
                {
                    sp.GetRequiredService<RegularCustomerShipping>(),
                    sp.GetRequiredService<VipCustomerShipping>(),
                    sp.GetRequiredService<BusinessCustomerShipping>()
                };

                return new ShippingStrategyFactory(strategies);
            });

        }
    }
}
