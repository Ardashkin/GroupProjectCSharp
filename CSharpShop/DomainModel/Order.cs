using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    [DataContract]
    public sealed class Order : BaseModel
    {
        [DataMember]
        [Required]
        public Guid UserId { get; set; }
        [DataMember]
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Id->{0}\nUserId->{1}\n", this.Id, this.UserId));
            sb.Append("Order products:\n");
            foreach (OrderProduct product in OrderProducts)
            {
                sb.Append(OrderProducts.ToString());
            }
            return sb.ToString();
        }
    }
}
