namespace DesignPattern.Controllers.BehavioralPatterns.Vistor
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Visitor is a behavioral design pattern that lets you separate algorithms from the objects on which they operate.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VistorController : ControllerBase
    {
        /// <summary>
        /// 
        /// Pros:
        ///     Open/Closed Principle. You can introduce a new behavior that can work with objects of different classes without changing these classes.
        ///     Single Responsibility Principle.You can move multiple versions of the same behavior into the same class.
        ///     A visitor object can accumulate some useful information while working with various objects.This might be handy when you want to traverse some complex object structure, such as an object tree, and apply the visitor to each object of this structure.
        ///     
        /// Cons:
        ///     You need to update all visitors each time a class gets added to or removed from the element hierarchy.
        ///     Visitors might lack the necessary access to the private fields and methods of the elements that they’re supposed to work with.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/visitor
        /// </summary>

        private readonly IProductDispatcher _productDispatcher;

        public VistorController(IProductDispatcher productDispatcher)
        {
            _productDispatcher = productDispatcher;
        }

        [HttpPost("process-dict")]
        public IActionResult ProcessOrderRegistry(OrderRequest request)
        {
            var products = new List<IProduct> { request.PhysicalProduct, request.DigitalProduct, request.MembershipProduct };

            foreach (var product in products)
            {
                _productDispatcher.Dispatch(product);
            }

            return Ok("Processed with registry-based visitor.");
        }

        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<IProductHandler<PhysicalProduct>, PhysicalProductHandler>();
            services.AddScoped<IProductHandler<DigitalProduct>, DigitalProductHandler>();
            services.AddScoped<IProductHandler<MembershipProduct>, MembershipProductHandler>();

            services.AddScoped<IProductDispatcher, ProductDispatcher>(sp =>
            {
                var dictionary = new Dictionary<ProductType, object>()
                {
                    { ProductType.PHYSICAL, sp.GetRequiredService<IProductHandler<PhysicalProduct>>() },
                    { ProductType.DIGITAL, sp.GetRequiredService<IProductHandler<DigitalProduct>>() },
                    { ProductType.MEMBERSHIP, sp.GetRequiredService<IProductHandler<MembershipProduct>>() }
                };

                return new ProductDispatcher(dictionary);
            });
        }
    }
}
