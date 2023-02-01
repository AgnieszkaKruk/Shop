using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using System.Collections.Generic;


namespace Codecool.CodecoolShop.Daos
{
    public interface IFilterResult
    {
        void GetFilterResult();
        bool IsNoProducts();
        bool IsNotChoosen();
        bool IsBothChoosen();
        bool IsCategoryOnly();
        bool IsSupplierOnly();
        List<Product> GetProducts();
    }
}
