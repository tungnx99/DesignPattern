namespace DesignPattern.Controllers.BehavioralPatterns.Observer
{
    public interface IEmailNotificationService
    {
        string SendEmail(string subject);
    }

    public class EmailNotificationService : IEmailNotificationService
    {
        public string SendEmail(string subject)
        {
            return $"Email sent with subject: {subject} successfully";
        }
    }
}
