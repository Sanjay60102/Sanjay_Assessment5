using System.ComponentModel.DataAnnotations;

namespace Assessment5.Entities
{
    public class Supplier
    {
        [Key]
        public string SupplierNo { get; set; }
        [Required]
        [MaxLength(15)]
        public string SupplierName { get; set; }
        [MaxLength(40)]
        public string Address { get; set; }
    }
}
