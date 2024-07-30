using Applications.Implement.Interfaces.Senders;
using Applications.Model.Models;
using Infrastructures.Implement.Services.Senders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Implement.Services.Senders
{
    public class MemberSenderService : ISenderAbstractFactory
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
