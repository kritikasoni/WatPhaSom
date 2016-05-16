using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.Repositories
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        Review GetById(int id);
        void Delete(int id);
        void Edit(Review r);
        void Add(Review r);
    }
}
