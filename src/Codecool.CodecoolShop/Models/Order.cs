using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class Order
    {
        //public int OrderId { get; set; }
        //public string CustomerFirstName { get; set; }
        //public int CustomerLastName { get; set; }   
        public decimal OrderValue { get; set; }
        public DateTime dataTime { get; set; } = DateTime.Now;
        public List<SingleProductInCart> produtsToOrder = new List<SingleProductInCart>();

    }
}
