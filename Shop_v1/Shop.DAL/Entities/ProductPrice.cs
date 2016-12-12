using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    class ProductPrice
    {
        public Guid PriceId { get; set; }

        public double Price { get; set; }

        public DateTime EffectiveDate { get; set; }
        //from this date
    }
}
