using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Component;
using DomainModel;

namespace Client.ViewModel
{
    public class ViewModelOrderAdd : ViewModelAdd<Order>
    {       
        protected override bool AddItemCommandCanExecute(object obj)
        {
            return this.Item.OrderProducts.Count() > 0;
        }
        protected override void AddItemCommandExecute(object obj)
        {
            service.Create(Item);
        }
    }
}
