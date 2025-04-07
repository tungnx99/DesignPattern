namespace DesignPattern.Controllers.BehavioralPatterns.State
{
    public interface IOrderState
    {
        void ProcessOrder(OrderContext orderData);
    }

    public class ProcessingState : IOrderState
    {
        public void ProcessOrder(OrderContext context)
        {
            Console.WriteLine("Order is being processed...");
            context.SetState(new ShippingState());
        }
    }

    public class ShippingState : IOrderState
    {
        public void ProcessOrder(OrderContext context)
        {
            Console.WriteLine("Order is being shipped...");
            context.SetState(new DeliveredState());
        }
    }

    public class DeliveredState : IOrderState
    {
        public void ProcessOrder(OrderContext context)
        {
            Console.WriteLine("Order has been delivered.");
        }
    }

    public class CancelledState : IOrderState
    {
        public void ProcessOrder(OrderContext context)
        {
            Console.WriteLine("Order has been cancelled.");
        }
    }

}
