using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.DAL
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public Guid PriceId { get; set; }
        public string Information { get; set; }


    }
}
