using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.DAL
{
    public class Order
    {
        [Key]
        public Guid Order_id { get; set; }

        public Guid Customer_id { get; set; }

        public List<OrderProduct> ProductId { get; set; }

    }
}
