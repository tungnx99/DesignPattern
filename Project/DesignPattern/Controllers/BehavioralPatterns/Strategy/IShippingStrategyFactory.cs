namespace DesignPattern.Controllers.BehavioralPatterns.Strategy
{
    public interface IShippingStrategyFactory
    {
        IShippingStrategy GetStrategy(CustomerType customerType);
    }

    public class ShippingStrategyFactory : IShippingStrategyFactory
    {
        private readonly Dictionary<CustomerType, IShippingStrategy> _strategies;

        public ShippingStrategyFactory(IEnumerable<IShippingStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.CustomerType);
        }

        public IShippingStrategy GetStrategy(CustomerType customerType)
        {
            if (_strategies.TryGetValue(customerType, out var strategy))
            {
                return strategy;
            }

            throw new ArgumentException("Invalid customer type.");
        }
    }

}
