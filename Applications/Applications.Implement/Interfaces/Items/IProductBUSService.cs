using Applications.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Implement.Interfaces.Items
{
    public interface IProductBUSService<T>
    {
        public T GetItem(Guid id);

        public T Create(T dto);

        public T Update(T dto);

        public bool Delete(Guid id);
    }
}
