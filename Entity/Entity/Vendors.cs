using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Vendors
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
