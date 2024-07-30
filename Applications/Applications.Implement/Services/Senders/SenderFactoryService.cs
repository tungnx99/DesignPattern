using Applications.Implement.Interfaces.Senders;
using Infrastructures.Share.Enums;

namespace Applications.Implement.Services.Senders
{
    public class SenderFactoryService : ISenderFactory
    {
        public ISenderAbstractFactory GetFactory(NotifySenderType notifySenderType)
        {
            if (notifySenderType == NotifySenderType.VIP)
                return new VVIPSenderService();

            if (notifySenderType == NotifySenderType.MEMBER)
                return new MemberSenderService();

            // ...

            throw new Exception();
        }
    }
}
