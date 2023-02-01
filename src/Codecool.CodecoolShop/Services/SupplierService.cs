using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class SupplierService
    {
        private readonly ISupplierDao supplierDao;

        public SupplierService(ISupplierDao supplierDao)
        {
            this.supplierDao = supplierDao;
        }
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return this.supplierDao.GetAll();
        }
    }
}
