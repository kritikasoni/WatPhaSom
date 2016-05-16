using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Service;
using Models.ViewModels;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        private NewsService _newsService;
        public NewsController(NewsService newsService)
        {
            this._newsService = newsService;
        }

        // GET: News
        public ActionResult Index()
        {
            return View(_newsService.GetAll());
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            return View(_newsService.GetById(id));
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create(NewsViewModel.NewsAddModel n)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
               _newsService.Add(n.GetNews());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_newsService.GetById(id));
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(News n)
        {
            try
            {
               _newsService.Edit(n);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

     

        // POST: News/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _newsService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
