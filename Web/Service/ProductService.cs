using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Repositories;

namespace Web.Service
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

       public Product GetById(string id)
       {
           return _productRepository.GetById(id);
       }

        public void Delete(string id)
        {
            _productRepository.Delete(id);
        }

        public void Edit(Product p)
        {
            _productRepository.Edit(p);
        }

        public void Add(Product p)
        {
            _productRepository.Add(p);
        }
    }
}