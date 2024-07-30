using Infrastructures.Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Models.Models
{
    public class NotifySenderEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public NotifySenderType Type { get; set; }


    }
}
