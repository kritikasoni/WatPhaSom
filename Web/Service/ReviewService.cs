using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Repositories;
using Models.Entities;

namespace Web.Service
{
    public class ReviewService
    {
        private IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            this._reviewRepository = reviewRepository;
        }
        public List<Review> GetAll()
        {
            return _reviewRepository.GetAll();
        }

        public Review GetById(int id)
        {
            return _reviewRepository.GetById(id);
        }

        public void Delete(int id)
        {
            _reviewRepository.Delete(id);
        }

        public void Edit(Review r)
        {
            _reviewRepository.Edit(r);
        }

        public void Add(Review r)
        {
            _reviewRepository.Add(r);
        }
    }
}