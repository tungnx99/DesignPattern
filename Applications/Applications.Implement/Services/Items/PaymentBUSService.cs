using Applications.Implement.Interfaces.Items;
using Applications.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Implement.Services.Items
{
    public class PaymentBUSService : IPaymentBUSService
    {
        public List<TicketDTO> BuildTicket(List<TicketDTO> dto)
        {
            throw new NotImplementedException();
        }

        public OrderDTO OrderStatus(Guid id)
        {
            throw new NotImplementedException();
        }

        public OrderDTO UpdateTicket(List<TicketDTO> ticket)
        {
            throw new NotImplementedException();
        }
    }
}
