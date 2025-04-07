namespace DesignPattern.Controllers.BehavioralPatterns.Mediator
{
    public interface IInventoryService
    {
        void UpdateStock(string productId, int quantity);
    }

    public class InventoryService : IInventoryService
    {
        public void UpdateStock(string productId, int quantity)
        {
            Console.WriteLine($"📦 Stock updated for product {productId} by quantity {quantity}");
        }
    }
}
