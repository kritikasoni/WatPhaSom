using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using Models.Repository;

namespace Models.Repositories
{
    public class CartRepository : ICartRepository

    {
        private EfDbContext _context;

        public CartRepository(EfDbContext context)
        {
            this._context = context;
        }

        public void Add(Cart c)
        {
            _context.Carts.Add(c);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cart = _context.Carts.Find(id);
            _context.Carts.Remove(cart);
            _context.SaveChanges();
        }

        public List<Cart> GetAll()
        {
            return _context.Carts.ToList();
        }

        public Cart GetById(int id)
        {
            return _context.Carts.First(p => p.Id.Equals(id));
        }
    }
}
