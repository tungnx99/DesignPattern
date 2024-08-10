using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Model.Models.Items
{
    public class HomeDetailDTO
    {
        public Guid HomeId { get; set; }

        public int Story { get; set; }

        public int Room { get; set; }
    }
}
