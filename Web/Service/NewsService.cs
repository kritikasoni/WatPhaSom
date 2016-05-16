using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Entities;

namespace Web.Service
{
    public class NewsService
    {
        private INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            this._newsRepository = newsRepository;
        }
        public List<News> GetAll()
        {
            return _newsRepository.GetAll();
        }

        public News GetById(int id)
        {
            return _newsRepository.GetById(id);

        }

        public void Delete(int id)
        {
            _newsRepository.Delete(id);
        }

        public void Edit(News n)
        {
            _newsRepository.Edit(n);
        }

        public void Add(News n)
        {
            _newsRepository.Add(n);
        }
    }
}