using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model.Models.Items
{
    public class TicketResponse
    {
        public long Code { get; set; }

        public Guid ObjectId { get; set; }

        public decimal Price { get; set; }

        public int Status { get; set; }
    }
}
