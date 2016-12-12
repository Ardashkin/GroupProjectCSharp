using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {      
        public long Artikul { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public float Cost { get; set; }
        public float Sale { get; set; }
        public float Sale_cost { get; set; }
        public long Amount_store { get; set; }
        public bool Visible { get; set; }
        public string Information { get; set; }
        public long Popularity { get; set; }        
    }
}
