namespace DesignPattern.Controllers.BehavioralPatterns.Command
{
    public class CustomerHandler : ICustomerHandler
    {
        public bool CreateCustomer(CustomerCommand customerCommand)
        {
            return true;
        }
    }
}
