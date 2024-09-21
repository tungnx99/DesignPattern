namespace Infrastructures.Implement.Services.Configs
{
    public interface IConfigService<T>
    {
        public T GetConfig();
    }
}
