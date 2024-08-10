using Applications.Model.Models.Items;
using DesignPattern.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Implement.Interface
{
    public interface IHomeProductService
    {
        public HomeDTO CreateOrUpdate(HomeRequest item);

        public HomeDTO GetItem(Guid id);

        public HomeDetailDTO BuildHome(HomeRequest item);
    }
}
