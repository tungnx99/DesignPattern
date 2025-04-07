namespace DesignPattern.Controllers.BehavioralPatterns.Observer
{
    public interface IOrderNotifier
    {
        string SubcriberNotify(SubscriberDataModel<string> model);
    }

    public class OrderNotifier : IOrderNotifier
    {
        private readonly IEmailNotificationService _emailNotificationService;
        private readonly ISmsNotificationService _smsNotificationService;

        public OrderNotifier(IEmailNotificationService emailNotificationService, ISmsNotificationService smsNotificationService)
        {
            _emailNotificationService = emailNotificationService;
            _smsNotificationService = smsNotificationService;
        }

        public string SubcriberNotify(SubscriberDataModel<string> model)
        {
            var result = string.Empty;

            switch (model.StatusCode)
            {
                case 1:
                    result += _emailNotificationService.SendEmail(model.Data);
                    break;
                case 2:
                    result += _smsNotificationService.SendSms(model.Data);
                    break;
                case 3:
                    result += _emailNotificationService.SendEmail(model.Data);
                    result += _smsNotificationService.SendSms(model.Data);
                    break;
                default:
                    throw new Exception("Unknown status code.");
            }

            return result;
        }
    }
}
