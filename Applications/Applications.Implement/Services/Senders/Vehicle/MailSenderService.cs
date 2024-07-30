using Applications.Model.Models;
using Infrastructures.Implement.Services.Senders;

namespace Applications.Implement.Services.Senders.Vehicle
{
    public class MailSenderService : ISender<MailSenderDTO>
    {
        public void Send(MailSenderDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
