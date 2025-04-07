namespace DesignPattern.Controllers.BehavioralPatterns.Mediator
{
    public class CreateOrderCommand
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerEmail { get; set; }
    }

    public interface ICreateOrderMediatorHandler
    {
        Task<string> Handle(CreateOrderCommand request);
    }

    public class CreateOrderMediatorHandler : ICreateOrderMediatorHandler
    {
        private readonly IEmailService _emailService;
        private readonly IInventoryService _inventoryService;
        private readonly ILoggerService _loggerService;

        public CreateOrderMediatorHandler(IEmailService emailService, IInventoryService inventoryService, ILoggerService loggerService)
        {
            _emailService = emailService;
            _inventoryService = inventoryService;
            _loggerService = loggerService;
        }

        public async Task<string> Handle(CreateOrderCommand request)
        {
            // Create order logic
            _loggerService.Log("Order is being created...");

            // Send confirmation email
            _emailService.SendEmail(request.CustomerEmail, "Thank you for your order!");

            // Update inventory
            _inventoryService.UpdateStock(request.ProductId, request.Quantity);

            // Write to log
            _loggerService.Log("Order created successfully.");

            return "Order created successfully.";
        }
    }
}
