using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model.Models.Items
{
    public class TicketUpdateRequest
    {
        public long Code { get; set; }

        public Guid ObjectId { get; set; }
    }
}
