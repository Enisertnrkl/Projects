using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.Entities.Abstract;

namespace L.Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
