using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Models.Entities;
using Models.Repositories;
using Models.ViewModels;
using Web.Models;
using Web.Service;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        private ProductService _productService;
        private IOrderProcessor orderProcessor;

        public CartController(ApplicationDbContext context, ProductService productService, IOrderProcessor orderProcessor)
        {
            _context = context;
            _productService = productService;
            this.orderProcessor = orderProcessor;
        }

        public CartController(Service.ProductService productService, IOrderProcessor proc)
        {

            this._productService = productService;
            orderProcessor = proc;
        }

        public ViewResult Summary(Cart cart)
        {
            return View(cart);
        }
        public ViewResult Index(string returnUrl)
        {
             Cart cart = GetCart();

            return View(new CartIndexViewModel
            {

                Cart = cart,
                ReturnUrl = returnUrl

            });

        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl, int amount)
        {

            Product product = _productService.GetById(productId);
               

            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, amount);
                Session["Cart"] = cart;

            }

            return RedirectToAction("Index", new {returnUrl});

        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {

            Product product = _productService.GetById(productId);

            if (product != null)
            {

                GetCart().RemoveLine(product);

            }

            return RedirectToAction("Index", new {returnUrl});

        }

        public RedirectToRouteResult UpdateLine(int productId, int newQuantity, string returnUrl)
        {

            Product product = _productService.GetById(productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.UpdateLine(product,newQuantity);
                Session["Cart"] = cart;
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ViewResult Checkout()
        {

            return View(new Order());

        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, Order order)
        {
            cart = GetCart();
            order.Username = User.Identity.GetUserName();
            order.OrderDetails = new List<OrderDetail>();
           
            try
            {
                if (cart.Lines.Count() == 0)
                {
                    ModelState.AddModelError("", "Sorry, your cart is empty!");
                }
                if (ModelState.IsValid)
                {
                    string role = User.IsInRole("Wholesale") ? "Wholesale" : "Retail";
                    orderProcessor.ProcessOrder(cart, order, role);
                    cart.Clear();
                    return View("Completed");
                }
                else
                {
                    return View(order);
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View(order);
            }
           
        }

        private Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
