using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Model.Models.Items
{
    public class OrderDTO
    {
        public Guid Id { get; set; }

        public long Code { get; set; }

        public IEnumerable<TicketDTO> Tickets { get; set; }

        public decimal Price { get; set; }
    }
}
