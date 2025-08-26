using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Entity;

namespace SajidStore.Models
{
    public class ItemViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }
        public string Name { get; set; } = string.Empty;
      //  public int ItemNo { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ParchingPrice { get; set; }

        public int TypeID { get; set; }
        [ForeignKey("TypeID")]
        public ItemTypesViewModel? ItemType { get; set; } = null;

        public int VendorID { get; set; }
        [ForeignKey("VendorID")]
        public virtual Vendors? Vendors { get; set; } = null;


    }
}
