using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Entities;
using Models.Repositories;

namespace Web.Service
{
    public class CartService
    {
        private ICartRepository _cartRepository;

        public CartService(ICartRepository newsRepository)
        {
            this._cartRepository = newsRepository;
        }
        public List<Cart> GetAll()
        {
            return _cartRepository.GetAll();
        }

        public Cart GetById(int id)
        {
            return _cartRepository.GetById(id);

        }

        public void Delete(int id)
        {
            _cartRepository.Delete(id);
        }

      public void Add(Cart c)
        {
            _cartRepository.Add(c);
        }
    }
}