using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SajidStore.Models
{
    public class AddItemViewModel
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        public decimal PurchingPrice { get; set; }

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
