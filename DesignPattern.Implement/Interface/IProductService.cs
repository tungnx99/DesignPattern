using DesignPattern.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Implement.Interface
{
    public interface IProductService<T>
    {
        public TicketResponse CaculateProductPrice(T product);

        public OrderResponse PaymentProduct(List<TicketUpdateRequest> ticketUpdate);

        public OrderResponse OrderStatus(Guid id);
    }
}
