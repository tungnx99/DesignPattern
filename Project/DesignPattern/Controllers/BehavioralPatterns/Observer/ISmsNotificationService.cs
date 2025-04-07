namespace DesignPattern.Controllers.BehavioralPatterns.Observer
{
    public interface ISmsNotificationService
    {
        string SendSms(string subject);
    }

    public class SmsNotificationService : ISmsNotificationService
    {
        public string SendSms(string subject)
        {
            return $"Sms sent with subject: {subject} successfully";
        }
    }
}
