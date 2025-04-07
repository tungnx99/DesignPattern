namespace DesignPattern.Controllers.BehavioralPatterns.State
{
    public class OrderContext
    {
        private IOrderState _state;

        public OrderContext()
        {
            _state = new ProcessingState();
        }

        public string GetState()
        {
            return _state.GetType().Name;
        }

        public void SetState(IOrderState state)
        {
            _state = state;
        }

        public void ProcessOrder()
        {
            _state.ProcessOrder(this);
        }
    }
}
