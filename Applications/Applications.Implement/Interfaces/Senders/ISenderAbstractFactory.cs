using Applications.Model.Models;
using Infrastructures.Implement.Services.Senders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Implement.Interfaces.Senders
{
    public interface ISenderAbstractFactory
    {
        ISender<MailSenderDTO> CreateMailSender(MailSenderDTO model);

        ISender<SMSSenderDTO> CreateSMSSender(SMSSenderDTO model);
    }
}
