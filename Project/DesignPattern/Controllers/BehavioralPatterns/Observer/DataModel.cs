namespace DesignPattern.Controllers.BehavioralPatterns.Observer
{
    public class SenderDataModel
    {
        public int StatusCode { get; set; }
        public string JsonData { get; set; }
    }

    public class SubscriberDataModel<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
