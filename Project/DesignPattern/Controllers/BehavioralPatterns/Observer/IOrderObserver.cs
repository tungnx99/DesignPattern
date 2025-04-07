namespace DesignPattern.Controllers.BehavioralPatterns.Observer
{
    public interface IOrderObserver
    {
        string OnSenderOrderStatusChanged(SenderDataModel order);
    }

    public class OrderObserver : IOrderObserver
    {
        private readonly IOrderNotifier _orderNotifier;

        public OrderObserver(IOrderNotifier orderNotifier)
        {
            _orderNotifier = orderNotifier;
        }

        public string OnSenderOrderStatusChanged(SenderDataModel order)
        {
            var orderSubscriber = new SubscriberDataModel<string>
            {
                StatusCode = order.StatusCode,
                Data = order.JsonData
            };
            
            return _orderNotifier.SubcriberNotify(orderSubscriber);
        }
    }
}
