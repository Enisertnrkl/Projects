using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.Entities.Concrete;

namespace L.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
