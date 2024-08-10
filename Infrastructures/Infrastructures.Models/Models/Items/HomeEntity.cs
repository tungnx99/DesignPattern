using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Models.Models.Items
{
    public class HomeEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CreatedBy { get; set; }

        public string CreatedByName { get; set; }
    }
}
