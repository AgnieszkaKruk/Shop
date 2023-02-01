using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public interface ICartManager
    {
        void AddProductToCart(int productId);
        void Add(int productId);
        void Substract(int productId);
        int GetHowManyProductsinCart();
        List<SingleProductInCart> GetProductsInCart();
        decimal GetValueCart();
        Order MakeNewOrder();
        void RemoveFromCart(int productId);
        public void UpadateProductAmount(int productAmount, int productId);
    }
}