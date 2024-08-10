using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model.Models.Items
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public long Code { get; set; }

        public IEnumerable<TicketResponse> Tickets { get; set; }

        public decimal Price { get; set; }
    }
}
