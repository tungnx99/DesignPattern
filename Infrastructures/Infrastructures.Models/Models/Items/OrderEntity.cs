using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Models.Models.Items
{
    public class OrderEntity
    {
        public Guid Id { get; set; }

        public long Code { get; set; }

        public IEnumerable<TicketEntity> Tickets { get; set; }

        public decimal Price { get; set; }
    }
}
