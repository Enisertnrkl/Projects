using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.Entities.Concrete;

namespace L.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
