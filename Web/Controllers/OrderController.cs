using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Models.Entities;
using Models.ViewModels;
using Web.Service;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
            
        }

        // GET: Order
        public ActionResult Index()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"] ?? "";
            ViewBag.SuccessMessage = TempData["SuccessMessage"] ?? "";

            var orders = _orderService
                                    .GetAll()
                                    .Where(o => o.Username.Equals(User.Identity.GetUserName()))
                                    .ToList();
            return View(orders == null ? new List<Order>() : orders);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AdminIndex()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"] ?? "";
            ViewBag.SuccessMessage = TempData["SuccessMessage"] ?? "";
            return View(_orderService.GetAll());
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            var order = _orderService.GetById(id);
            if (!order.Username.Equals(User.Identity.GetUserName()) || User.IsInRole("Admin"))
            {
                TempData["ErrorMessage"] = "Sorry, it's someone else people order";
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Order/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var order = _orderService.GetById(id);
            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Order order)
        { 
            try
            {
               // order.Updated = DateTime.Now;
                _orderService.Edit(order);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorMessage"] = "Update fail";
                return View(order);
            }
        }

        // POST: Order/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int orderId)
        {
            try
            {
                _orderService.Delete(orderId);
                TempData["SuccessMessage"] = "Delete order id: " + orderId + " success";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorMessage"] = "Delete order id: " + orderId + " fail";
                return RedirectToAction("Index");
            }
        }

    

       
    }
}
