using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model.Models.Senders
{
    public class SenderCreateRequest
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
