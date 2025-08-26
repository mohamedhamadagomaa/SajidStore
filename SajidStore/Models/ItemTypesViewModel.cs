using Entity.Entity;
using System.ComponentModel.DataAnnotations;

namespace SajidStore.Models
{
    public class ItemTypesViewModel
    {
        [Key]
        public int TypeID { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
