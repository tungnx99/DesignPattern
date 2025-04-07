namespace DesignPattern.Controllers.BehavioralPatterns.Vistor
{
    public interface IProductDispatcher
    {
        void Dispatch(IProduct product);
    }

    public class ProductDispatcher : IProductDispatcher
    {
        private readonly Dictionary<ProductType, object> _handlers;

        public ProductDispatcher(Dictionary<ProductType, object> handlers)
        {
            _handlers = handlers;
        }

        public void Dispatch(IProduct product)
        {
            if (_handlers.TryGetValue(product.Type, out var handler))
            {
                var method = handler.GetType().GetMethod("Handle");
                method?.Invoke(handler, new[] { product });
            }
            else
            {
                Console.WriteLine($"[SKIP] No handler registered for {product.Type}");
            }
        }
    }
}
