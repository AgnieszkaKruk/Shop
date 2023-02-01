using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Codecool.CodecoolShop.Services
{
    public class CartManager :  ICartManager
    {  
        public int CartId { get; set; }
        public List<SingleProductInCart> productsInCart = new List<SingleProductInCart>();
        private readonly Daos.IProductDao productDao = ProductDaoMemory.GetInstance();
       
        public List<SingleProductInCart> GetProductsInCart()
        {

            return productsInCart;
                
        }

        public void AddProductToCart(int productId)
        {
            var cart = GetProductsInCart();
            var productAlreadyInCart = cart.FirstOrDefault(p => p.product.Id == productId);


            if (productAlreadyInCart != null)
            {
                productAlreadyInCart.HowMany++;
               
            }
            else
            {
                var product = productDao.GetAll().Where(p => p.Id == productId).SingleOrDefault();
                var newProductToCart = new SingleProductInCart
                {
                    CartId = CartId,
                    product = product,
                    HowMany = 1,
                    Value = product.DefaultPrice

                };
                productsInCart.Add(newProductToCart);
            }

        }

        public void Substract(int productId)
        {
            var cart = GetProductsInCart();
            var productAlreadyInCart = productsInCart.FirstOrDefault(p => p.product.Id == productId);

                if (productAlreadyInCart.HowMany > 1)
                {
                    productAlreadyInCart.HowMany--;   
                }
                else
                {
                    cart.Remove(productAlreadyInCart);
                } 
        }

        public void Add(int productId)
        {
            var cart = GetProductsInCart();
            var productAlreadyInCart = cart.FirstOrDefault(p => p.product.Id == productId);
            productAlreadyInCart.HowMany++;
            


        }


        public int GetHowManyProductsinCart()
        {
            var cart = GetProductsInCart();
            int howManyProductsInCart = productsInCart.Sum(p => p.HowMany);
            return howManyProductsInCart;
        }

        public decimal GetValueCart()
        {
            var cart = GetProductsInCart();
            decimal valueCart = 0;
            foreach (var product in cart)
            {
                var valueTheSameProducts = product.Value * product.HowMany;
                valueCart += valueTheSameProducts;
            }
            return valueCart;
        }

        public void ClearCart()
        {
            var cart = GetProductsInCart();
            foreach (var product in cart)
            {
                cart.Remove(product);
            }

        }

        public Order MakeNewOrder()
        {
            var cart = GetProductsInCart();
            var newOrder = new Order();
            newOrder.produtsToOrder = cart;
            newOrder.OrderValue = GetValueCart();
            newOrder.dataTime = DateTime.Now;
            return newOrder;
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetProductsInCart();
            var productAlreadyInCart = cart.FirstOrDefault(p => p.product.Id == productId);
            cart.Remove(productAlreadyInCart);
        }

        public void UpadateProductAmount(int productAmount, int productId)
        {
            var cart = GetProductsInCart();
            var productAlreadyInCart = cart.FirstOrDefault(p => p.product.Id == productId);
            productAlreadyInCart.HowMany = productAmount;

        }
    }
}


