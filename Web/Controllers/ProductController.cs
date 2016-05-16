using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Repository.ViewModels;
using Web.Service;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductService _productService;

        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(_productService.GetById(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel.ProductAddModel p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {   //make name,price,description,image=collection and add description
                _productService.Add(p.GetProduct());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_productService.GetById(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            try
            {
                _productService.Edit(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

       
    }
}
