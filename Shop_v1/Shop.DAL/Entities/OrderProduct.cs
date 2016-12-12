using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.DAL
{
    public class OrderProduct
    {
        [Key]
        
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
