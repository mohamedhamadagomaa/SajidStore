using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SajidStore.Models
{
    public class EditItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PurchasingPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Display(Name = "Item Type")]
        [Required(ErrorMessage = "Please select an item type")]
        public int SelectedItemTypeID { get; set; }

        public IEnumerable<SelectListItem> ItemTypes { get; set; } = new List<SelectListItem>();

        [Display(Name = "VendorID")]
        [Required(ErrorMessage = "Please select a vendor")]
        public int SelectedVendorID { get; set; }
        public IEnumerable<SelectListItem> Vendors { get; set; } = new List<SelectListItem>();
    }
}
