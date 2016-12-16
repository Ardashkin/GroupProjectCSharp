using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DomainModel
{
    [Flags]
    [DataContract]
    public enum OrderStatus : byte
    {
        [EnumMember]
        IsCancelled,
        [EnumMember]
        IsProcessing,
        [EnumMember]
        IsComfirmed,
        [EnumMember]
        IsSend
    }
}
