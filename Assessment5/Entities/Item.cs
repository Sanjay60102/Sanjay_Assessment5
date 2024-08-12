using System.ComponentModel.DataAnnotations;

namespace Assessment5.Entities
{
    public class Item
    {
        [Key]
        public string ItCode { get; set; }
        [Required]
        [MaxLength(15)]
        public string ItDesc { get; set; }
        public decimal ItRate { get; set; }
    }
}
