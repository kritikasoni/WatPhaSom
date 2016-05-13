
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Entities;
using System.Data.Entity;

namespace Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private EfDbContext _context;
        public ProductRepository(EfDbContext context)
        {
            this._context = context;
        }

        public void Add(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
          
        }

        public void Delete(string id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Edit(Product p)
        {
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(string id)
        {
            return _context.Products.First(p => p.Id.Equals(id));
        }
    }
}
