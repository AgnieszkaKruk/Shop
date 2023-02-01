using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Services;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Models
{
    public class FilterResult : IFilterResult
    {
        public int ProductCategoryId { get; set; }
        public int ProductSupplierId { get; set; }
        public List<Product> products = new List<Product>();
        public IEnumerable<Product> categoryProducts = new List<Product>();
        public IEnumerable<Product> supplierProducts = new List<Product>();
        public ProductService ProductService { get; set; }
        public FilterResult()
        {
            ProductService = new ProductService(
            ProductDaoMemory.GetInstance(),
            ProductCategoryDaoMemory.GetInstance(),
            SupplierDaoMemory.GetInstance());
        }
        public void GetFilterResult()
        {
            foreach (Product pr in this.categoryProducts)
            {
                if (this.supplierProducts.Contains(pr))
                {
                    this.products.Add(pr);
                }
            }
        }
        public bool IsNoProducts()
        {
            return !this.products.Any();
        }
        public bool IsNotChoosen()
        {
            if (this.ProductCategoryId == 0 && this.ProductSupplierId == 0) return true;
            return false;
        }
        public bool IsBothChoosen()
        {
            if (this.ProductCategoryId != 0 && this.ProductSupplierId != 0)
            {
                this.categoryProducts = ProductService.GetProductsForCategory(int.Parse(this.ProductCategoryId.ToString())).ToList();
                this.supplierProducts = ProductService.GetProductsForSupplier(int.Parse(this.ProductSupplierId.ToString())).ToList();
                GetFilterResult();
                return true;
            }
            return false;
        }
        public bool IsCategoryOnly()
        {
            if (this.ProductCategoryId != 0 && this.ProductSupplierId == 0)
            {
                this.categoryProducts = ProductService.GetProductsForCategory(int.Parse(this.ProductCategoryId.ToString())).ToList();
                this.products = this.categoryProducts.ToList();
                return true;
            }
            return false;
        }
        public bool IsSupplierOnly()
        {
            if (this.ProductCategoryId == 0 && this.ProductSupplierId != 0)
            {
                this.supplierProducts = ProductService.GetProductsForSupplier(int.Parse(this.ProductSupplierId.ToString())).ToList();
                this.products = this.supplierProducts.ToList();
                return true;
            }
            return false;
        }
        public List<Product> GetProducts()
        {
            return this.products;
        }
    }
}
