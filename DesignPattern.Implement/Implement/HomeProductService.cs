using Applications.Implement.Interfaces.Items;
using Applications.Model.Models.Items;
using AutoMapper;
using DesignPattern.Implement.Interface;
using DesignPattern.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Implement.Implement
{
    public class HomeProductService : IHomeProductService
    {
        private readonly IProductBUSService<HomeDTO> _productBUSService;
        private readonly IProductBUSService<HomeDetailDTO> _productDetailBUSService;
        private readonly IMapper _mapper;

        public HomeProductService(IProductBUSService<HomeDTO> productBUSService, IMapper mapper, IProductBUSService<HomeDetailDTO> productDetailBUSService)
        {
            _productBUSService = productBUSService;
            _mapper = mapper;
            _productDetailBUSService = productDetailBUSService;
        }

        public HomeDetailDTO BuildHome(HomeRequest item)
        {
            var dto = _mapper.Map<HomeDetailDTO>(item);

            // design home ... room, story, ...
            // ...

            var homeDetail = _productDetailBUSService.Create(dto);

            return homeDetail;
        }

        public HomeDTO CreateOrUpdate(HomeRequest item)
        {
            var home = item.Id.HasValue ?
                            _productBUSService.Update(_mapper.Map<HomeDTO>(item)) :
                            _productBUSService.Create(_mapper.Map<HomeDTO>(item));

            return home;
        }

        public HomeDTO GetItem(Guid id)
        {
            return _productBUSService.GetItem(id);
        }
    }
}
