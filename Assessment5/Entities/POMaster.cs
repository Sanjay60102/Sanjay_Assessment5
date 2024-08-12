using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assessment5.Entities
{
    public class POMaster
    {
        [Key]
        public string PONo { get; set; }
        public DateTime PODate { get; set; }
        [ForeignKey("Item")]
        public string ItCode { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Supplier")]
        public string SupplierNo { get; set; }

        //Navigation Properties
        [JsonIgnore]
        public Item Item { get; set; }
        [JsonIgnore]
        public Supplier Supplier { get; set; }
    }
}
