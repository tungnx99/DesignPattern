using Applications.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Implement.Interfaces.Items
{
    public interface IPaymentBUSService
    {
        public List<TicketDTO> BuildTicket(List<TicketDTO> dto);

        public OrderDTO UpdateTicket(List<TicketDTO> ticket);

        public OrderDTO OrderStatus(Guid id);
    }
}
