namespace Infrastructures.Implement.Services.Senders
{
    public interface ISender<T>
    {
        public void Send(T model);
    }
}
