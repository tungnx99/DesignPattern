namespace DesignPattern.Controllers.BehavioralPatterns.Strategy
{
    public enum CustomerType
    {
        REGULAR,
        VIP,
        BUSINESS
    }

    public interface IShippingStrategy
    {
        decimal CalculateShippingFee(decimal orderAmount);
        CustomerType CustomerType { get; }
    }

    public class RegularCustomerShipping : IShippingStrategy
    {
        public CustomerType CustomerType => CustomerType.REGULAR;
        public decimal CalculateShippingFee(decimal orderAmount) => orderAmount * 0.1m;
    }

    public class VipCustomerShipping : IShippingStrategy
    {
        public CustomerType CustomerType => CustomerType.VIP;
        public decimal CalculateShippingFee(decimal orderAmount) => orderAmount * 0.05m;
    }

    public class BusinessCustomerShipping : IShippingStrategy
    {
        public CustomerType CustomerType => CustomerType.BUSINESS;
        public decimal CalculateShippingFee(decimal orderAmount) => 0;
    }

}
