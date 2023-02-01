using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Http;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private ICartManager _cartManager;
        private Payment _payment = new Payment();
        private string test;
        public ProductService ProductService { get; set; } //do konstruktora jako paramert
        public SupplierService SupplierService { get; set; } //jw

        public ProductController(ILogger<ProductController> logger, ICartManager cartManager)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
            
                SupplierDaoMemory.GetInstance()
                );
            _cartManager = cartManager;
            SupplierService = new SupplierService(SupplierDaoMemory.GetInstance());
        }




        public IActionResult Index()
        {
            ViewData["Categories"] = ProductService.GetAllCategories().ToList();
            ViewData["Suppliers"] = SupplierService.GetAllSuppliers().ToList();
            var products = ProductService.GetAllProducts();
            return View(products.ToList());
        }

        [HttpPost]
        public IActionResult Index(FilterResult filterResult)
        {
            ViewData["Categories"] = ProductService.GetAllCategories().ToList();
            ViewData["Suppliers"] = SupplierService.GetAllSuppliers().ToList();
            if (filterResult.IsNotChoosen())
                return RedirectToAction("Index");
            else if (filterResult.IsBothChoosen())
            {
                if (filterResult.IsNoProducts())
                    return View("Empty");
            }
            else if (filterResult.IsCategoryOnly())
            {
                if (filterResult.IsNoProducts())
                    return View("Empty");
            }
            else if (filterResult.IsSupplierOnly())
            {
                if (filterResult.IsNoProducts())
                    return View("Empty");
            }
            return View(filterResult.GetProducts());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PaymentPage()
        {
            return View(_payment);
        }
        [HttpPost]
        public void PaymentPage([FromBody] string totalValue)
        {
            Payment.PaymentValue = totalValue;
        }

        [HttpPost]
        public ActionResult PaymentConfirmation(IFormCollection form)
        {
            var paymentMethod = form["paymentMethod"].ToString();
            _payment.PaymentName = paymentMethod;
            return View(_payment);
        }

        public IActionResult Empty()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

        public RedirectToActionResult AddToCart(int productID)
        {
            _cartManager.AddProductToCart(productID);
            return RedirectToAction("Index");
        }




    }
}
