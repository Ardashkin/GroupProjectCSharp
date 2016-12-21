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
    [DataContract(IsReference = true)]
    public abstract class BaseModel
    {
        [DataMember]
        public Guid Id { get; set; }
    }
}
