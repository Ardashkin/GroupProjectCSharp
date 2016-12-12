using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class OrderCartModel
    {
        [Key]
        public Int64 Order_Cart_id { get; set; }
        public Int64 Order_id { get; set; }
        public Int64 Orders_id { get; set; }
    }
}
