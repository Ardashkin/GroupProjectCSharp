using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Component;
using DomainModel;

namespace Client.ViewModel
{
    public class ViewModelOrderEdit : ViewModelEdit<Order>
    {       
        protected override bool EditItemCommandCanExecute(object obj)
        {
            return this.SelectedItem.OrderProducts.Count() > 0;
        }

        protected override void EditItemCommandExecute(object obj)
        {
            service.Update(SelectedItem);
        }
    }
}
