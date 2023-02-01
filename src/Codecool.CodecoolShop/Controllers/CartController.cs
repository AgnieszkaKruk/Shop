using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Codecool.CodecoolShop.Data;



namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        private ICartManager _cartManager;

        public CartController(ICartManager cart, ApplicationDbContext db)
        {
            _cartManager = cart;
            _db = db;
        }

        public IActionResult Index()
        {
                var productsInCart = _db.ProductsInCart.ToList();
            //var productsInCart = _cartManager.GetProductsInCart();
            return View(productsInCart.ToList());
        }


        public RedirectToActionResult RemoveFromCart(int productID)
        {
            _cartManager.RemoveFromCart(productID);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Substract(int productID)
            {
               _cartManager.Substract(productID);
                
                return RedirectToAction("Index");
            }

        public RedirectToActionResult Add(int productID)
        {
            _cartManager.Add(productID);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult UpdateProductAmount(int productAmount,int productID)
        {
            _cartManager.UpadateProductAmount(productAmount,productID);

            return RedirectToAction("Index");
        }

    }
}
