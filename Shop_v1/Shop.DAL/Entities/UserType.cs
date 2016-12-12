using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    class UserType
    {
        //enum
        public Guid UserTypeId { get; set; }
        public string Type { get; set; }
    }
}
