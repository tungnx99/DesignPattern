using Applications.Implement.Interfaces.Senders;
using Applications.Model.Models;
using Infrastructures.Implement.Services.Senders;

namespace Applications.Implement.Services.Senders
{
    public class VVIPSenderService : ISenderAbstractFactory
    {
        public ISender<MailSenderDTO> CreateMailSender(MailSenderDTO model)
        {
            throw new NotImplementedException();
        }

        public ISender<SMSSenderDTO> CreateSMSSender(SMSSenderDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
