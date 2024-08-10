using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Models.Models.Items
{
    public class HomeDetailEntity
    {
        public Guid Id { get; set; }

        public Guid HomeId { get; set; }

        public int Story { get; set; }

        public int Room { get; set; }
    }
}
