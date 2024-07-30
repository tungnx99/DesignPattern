using Infrastructures.Share.Enums;

namespace Applications.Implement.Interfaces.Senders
{
    public interface ISenderFactory
    {
        public ISenderAbstractFactory GetFactory(NotifySenderType notifySenderType);
    }
}
