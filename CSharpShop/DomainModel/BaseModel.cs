using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Specialized;

namespace DomainModel
{
    [DataContract]
    public abstract class BaseModel : INotifyPropertyChanged, IDataErrorInfo
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual string this[string propertyName] { get { return Error; } }
        public virtual string Error
        {
            get { return String.Empty; }
        }
    }
}
