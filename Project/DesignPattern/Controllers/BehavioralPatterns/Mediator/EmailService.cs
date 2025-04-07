namespace DesignPattern.Controllers.BehavioralPatterns.Mediator
{
    public interface IEmailService
    {
        void SendEmail(string to, string message);
    }

    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string message)
        {
            Console.WriteLine($"📧 Email sent to {to}: {message}");
        }
    }
}
