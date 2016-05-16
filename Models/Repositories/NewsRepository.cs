using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using Models.Repository;
using System.Data.Entity;

namespace Models.Repositories
{
    class NewsRepository : INewsRepository
    {
        private EfDbContext _context;
        public NewsRepository(EfDbContext context)
        {
            this._context = context;
        }
        public void Add(News n)
        {
            _context.NewsList.Add(n);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var news = _context.NewsList.Find(id);
            _context.NewsList.Remove(news);
            _context.SaveChanges();
        }

        public void Edit(News n)
        {
            _context.Entry(n).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<News> GetAll()
        {
            return _context.NewsList.ToList();
        }

        public News GetById(int id)
        {
            return _context.NewsList.First(n => n.Id.Equals(id));
        }
    }
}
