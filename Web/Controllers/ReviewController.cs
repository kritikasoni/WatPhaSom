using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Entities;
using Models.ViewModels;
using Web.Service;

namespace Web.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            this._reviewService = reviewService;
        }
        // GET: Review
        public ActionResult Index()
        {
            return View(_reviewService.GetAll());
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            return View(_reviewService.GetById(id));
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(ReviewViewModel.ReviewAddModel r)
        {
            System.Diagnostics.Debug.WriteLine(r.GetReview().ProductId);

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Product", new {id = r.GetReview().ProductId});
            }
            try
            {
                _reviewService.Add(r.GetReview());

                return RedirectToAction("Details", "Product", new { id = r.GetReview().ProductId });
            }
            catch
            {
                return RedirectToAction("Details", "Product", new { id = r.GetReview().ProductId });
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_reviewService.GetById(id));
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(Review r)
        {
            try
            {
                _reviewService.Edit(r);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       // POST: Review/Delete/5
        [HttpGet]
        public void Delete(int id)
        {
            try
            {
                _reviewService.Delete(id);

                Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            }
            catch
            {
                Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            }
        }
    }
}
