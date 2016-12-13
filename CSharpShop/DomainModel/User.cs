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
    [DataContract]
    public sealed class User : BaseModel
    {
        private string firstName;
        private string lastName;
        private string patronimic;
        private string login;
        private string password;
        private string phone;
        private string address;
        private UserType userType;
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(this.FirstName));
            }
        }
        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(this.LastName));
            }
        }
        [DataMember]
        public string Patronimic
        {
            get { return patronimic; }
            set
            {
                patronimic = value;
                OnPropertyChanged(nameof(this.Patronimic));
            }
        }
        [DataMember]
        [Required(ErrorMessage = "Login is required")]
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged(nameof(this.Login));
            }
        }
        [DataMember]
        [Required(ErrorMessage = "Password is required")]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(this.Password));
            }
        }
        [DataMember]
        [Required(ErrorMessage = "Phone is required")]
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(this.Phone));
            }
        }
        [DataMember]
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(this.Address));
            }
        }
        [DataMember]
        [Required]
        public UserType UserType
        {
            get { return userType; }
            set
            {
                userType = value;
                OnPropertyChanged(nameof(this.UserType));
            }
        }
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
