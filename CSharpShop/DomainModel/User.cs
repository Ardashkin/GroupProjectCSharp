using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace DomainModel
{
    [DataContract(IsReference = true)]
    public class User : BaseModel
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Patronimic { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        [Required]
        public UserType UserType { get; set; }
        public override string ToString()
        {
            return String.Format("Id->{0}\nFirst name->{1}\nLast name->{2}\nPatronimic->{3}\nLogin->{4}\nPassword->{5}\nPhone->{6}\nAddress->{7}\nUser type->{8}\n",
                this.Id,
                this.FirstName,
                this.LastName,
                this.Patronimic,
                this.Login,
                this.Password,
                this.Phone,
                this.Address,
                Enum.GetName(typeof(UserType), this.UserType)
                );
        }
    }
}
