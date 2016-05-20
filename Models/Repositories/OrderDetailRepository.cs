using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using Models.Repository;

namespace Models.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private EfDbContext _context;
        public OrderDetailRepository(EfDbContext context)
        {
            this._context = context;
        }
        public void Add(OrderDetail od)
        {
            _context.OrderDetails.Add(od);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderdetail = _context.OrderDetails.Find(id);
            _context.OrderDetails.Remove(orderdetail);
            _context.SaveChanges();
        }

        public void Edit(OrderDetail od)
        {
            _context.Entry(od).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<OrderDetail> GetAll()
        {
            return _context.OrderDetails.ToList();
        }

        public OrderDetail GetById(int id)
        {
            return _context.OrderDetails.First(p => p.Id.Equals(id));
        }
    }
}
