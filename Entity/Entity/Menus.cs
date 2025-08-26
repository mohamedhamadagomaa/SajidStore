using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Menus 
    {
        [Key]
        public int MenuID { get; set; }
        public string MenuName { get; set; } 
        public string Controller { get; set; } 
        public string Action { get; set; } 
        public string Description { get; set; }


    }
}
