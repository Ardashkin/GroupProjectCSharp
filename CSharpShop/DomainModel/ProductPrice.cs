using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [DataContract]
    public class ProductPrice : BaseModel
    {
        [DataMember]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Effective date is required")]
        public DateTime EffectiveDate { get; set; }
        public override string ToString()
        {
            return String.Format("Id->{0}\nPrice->{1}\nEffectiveDate->{2}\n",
                this.Id,
                this.Price,
                this.EffectiveDate.ToShortDateString()
                );
        }
    }
}
