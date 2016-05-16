using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
   public  interface INewsRepository
    {
        List<News> GetAll();
        News GetById(int id);
        void Delete(int id);
        void Edit(News n);
        void Add(News n);
    }
}
