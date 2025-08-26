using System.ComponentModel.DataAnnotations;
using Entity.Entity;

namespace SajidStore.Models
{
    public class VendorsViewModel
    {
        [Key]
        public int VendorID { get; set; }
        public string VName { get; set; }
        public string VAdress { get; set; }
        public string VPhone { get; set; }
        public string VEmail { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
