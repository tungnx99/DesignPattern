using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Models.Models.Items
{
    public class TicketEntity
    {
        public Guid Id { get; set; }

        public long Code { get; set; }

        public Guid ObjectId { get; set; }

        public decimal Price { get; set; }

        public int Status { get; set; }
    }
}
