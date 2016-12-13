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
    public class User : BaseModel
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
        [Required]
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
        [Required]
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
        [Required]
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
    }
}
