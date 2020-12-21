using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
   
        public class Products
        {
            [Key]
            public int ID_Product { get; set; }
            public string Title_Product { get; set; }
            public string Description_Product { get; set; }
            public int Price_Product { get; set; }
        }
    }

