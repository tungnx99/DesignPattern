namespace DesignPattern.Controllers.BehavioralPatterns.Mediator
{
    public interface ILoggerService
    {
        void Log(string message);
    }

    public class LoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine($"📝 Log: {message}");
        }
    }
}
