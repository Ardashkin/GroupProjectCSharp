using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class OrdersModel
    {
        public bool Buy { get; set; }
        public Int64 Orders_id { get; set; }
        public string User_id { get; set; }
        public string IP { get; set; }

        [Display(Name = "Артикул товара")]
        public Int64 Artikul { get; set; }

        public string Name { get; set; }

        public string Mark { get; set; }

        public float Cost { get; set; }

        [Display(Name = "Количество (шт.)")]
        [Range(1, 1000)]
        public int Number { get; set; }        
        public DateTime date { get; set; }
        public Int64 State { get; set; }
        [Display(Name = "Состояние")]
        public string StateName { get; set; }
    }
}
