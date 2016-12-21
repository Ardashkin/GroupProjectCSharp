using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [DataContract]
    public class Product : BaseModel
    {
        [DataMember]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [DataMember]
        [Required]
        public Guid ProductPriceId { get; set; }
        public virtual ProductPrice Price { get; set; }
        [DataMember]
        public string Description { get; set; }
        public override string ToString()
        {
            return String.Format("Id->{0}\nProductPriceId->{1}\nTitle->{2}\nDescription->{2}\n",
                this.Title,
                this.ProductPriceId,
                this.Description
                );
        }
    }
}
