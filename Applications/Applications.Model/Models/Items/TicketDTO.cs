using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Model.Models.Items
{
    public class TicketDTO
    {
        public Guid Id { get; set; }

        public long Code { get; set; }

        public Guid ObjectId { get; set; }

        public decimal Price { get; set; }

        public int TicketStatus { get; set; }
    }
}
