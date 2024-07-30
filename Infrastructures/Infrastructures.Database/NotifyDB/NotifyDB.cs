using Infrastructures.Models.Models;

namespace Infrastructures.Database.NotifyDB
{
    public class NotifyDB
    {
        public IEnumerable<NotifySenderEntity> NotifySenders { get; set; }
    }
}
