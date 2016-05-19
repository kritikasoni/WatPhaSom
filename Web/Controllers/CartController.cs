using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Entities;
using Models.Repositories;
using Models.Repository;
using Models.ViewModels;
using Web.Service;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private ProductService _productService;
     //   private IOrderProcessor orderProcessor;

        public CartController(ProductService productService)
        {

            this._productService = productService;

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

        public ViewResult Checkout(Cart cart, Order orders)
        {

            if (cart.Lines.Count() == 0)
            {

                ModelState.AddModelError("", "Sorry, your cart is empty!");

            }

         /*   if (ModelState.IsValid)
            {

                orderProcessor.ProcessOrder(cart, orderDetails);

                cart.Clear();

                return View("Completed");

            }*/
            else
            {

               

            }
 return View();
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
