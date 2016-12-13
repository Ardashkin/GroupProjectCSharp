using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace DomainModel
{
    [DataContract]
    public abstract class BaseModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public bool HasErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [DataMember]
        [Key]
        public Guid Id { get; set; }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
