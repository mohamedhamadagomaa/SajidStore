using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int SerialNumber { get; set; } 
        public string Name { get; set; } = string.Empty;

        //public int ItemNo { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ParchingPrice {get; set;}
        public int TypeID { get; set; }

        [ForeignKey("TypeID")]
        public virtual ItemTypes? ItemType { get; set; } 

        public int VendorID { get; set; }
        [ForeignKey("VendorID")]
        public virtual Vendors? Vendors { get; set; }
    }
}
