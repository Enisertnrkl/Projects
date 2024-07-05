using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.DataAccess.Abstract;
using L.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace L.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        private readonly EfLContext _context = new EfLContext();
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetSingle(Product entity)
        {
            return _context.Products.SingleOrDefault(entity);
        }

        public void Add(Product entity)
        {
           var addedProduct = _context.Products.Entry(entity);
           addedProduct.State = EntityState.Added;
           _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            var updatedProduct = _context.Products.Entry(entity);
            updatedProduct.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            var deletedProduct = _context.Products.Entry(entity);
            deletedProduct.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
