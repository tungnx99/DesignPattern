namespace DesignPattern.Controllers.BehavioralPatterns.Command
{
    public interface ICustomerHandler
    {
        public bool CreateCustomer(CustomerCommand customerCommand);
    }
}
