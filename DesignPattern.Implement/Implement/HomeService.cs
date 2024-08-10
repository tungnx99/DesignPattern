using Applications.Implement.Interfaces.Items;
using Applications.Implement.Services.Items;
using Applications.Model.Models.Items;
using AutoMapper;
using DesignPattern.Implement.Interface;
using DesignPattern.Model.Models.Items;

namespace DesignPattern.Implement.Implement
{
    public class HomeService : IProductService<HomeRequest>
    {
        private readonly IHomeProductService _homeProductService;
        private readonly IPaymentBUSService _paymentBUSService;
        private readonly IMapper _mapper;

        public HomeService(IMapper mapper, IPaymentBUSService paymentBUSService, IHomeProductService homeProductService)
        {
            _mapper = mapper;
            _paymentBUSService = paymentBUSService;
            _homeProductService = homeProductService;
        }

        public TicketResponse CaculateProductPrice(HomeRequest product)
        {
            try
            {
                var home = product.IsCreateOrUpdate ? _homeProductService.CreateOrUpdate(product) : _homeProductService.GetItem(product.Id.Value);

                var homeDetail = _homeProductService.BuildHome(product);

                var ticket = _paymentBUSService.BuildTicket(MappingTicket(home, homeDetail));

                return _mapper.Map<TicketResponse>(ticket);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OrderResponse OrderStatus(Guid id)
        {
            return _mapper.Map<OrderResponse>(_paymentBUSService.OrderStatus(id));
        }

        public OrderResponse PaymentProduct(List<TicketUpdateRequest> ticketUpdate)
        {
            try
            {
                var order = _paymentBUSService.UpdateTicket(_mapper.Map<List<TicketDTO>>(ticketUpdate));

                return _mapper.Map<OrderResponse>(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<TicketDTO> MappingTicket(HomeDTO home, HomeDetailDTO detail)
        {
            return new List<TicketDTO>();
        }
    }
}
