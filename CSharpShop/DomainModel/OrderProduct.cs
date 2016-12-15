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
    public sealed class OrderProduct : BaseModel
    {
        private int quantity;
        [DataMember]
        [Required]
        public Guid OrderId { get; set; }
        [DataMember]
        [Required]
        public Guid ProductId { get; set; }
        [DataMember]
        [Required(ErrorMessage ="Quantity is required")]
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(this.Quantity));
            }
        }
        public override string ToString()
        {
            return String.Format("Id->{0}\nOrderId->{1}\nProductId->{2}\nQuantity->{3}\n",
                this.Id,
                this.OrderId,
                this.ProductId,
                this.Quantity
                );
        }
    }
}
