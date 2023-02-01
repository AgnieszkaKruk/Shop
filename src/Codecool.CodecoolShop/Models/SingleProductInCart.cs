using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codecool.CodecoolShop.Models
{
    public class SingleProductInCart

    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }

        public int HowMany { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }
        


    }
}
