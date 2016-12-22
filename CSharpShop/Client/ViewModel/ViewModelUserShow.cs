using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Client.Component;

namespace Client.ViewModel
{
    public class ViewModelUserShow : ViewModelShow<User>
    {
        public override void GetData()
        {
            Reset();
            foreach (var element in service.GetItems())
            {
                obsCollection.Add((User)element);
            }
        }
        protected override void OpenViewCommandExecute(object obj)
        {
            GetData();
        }
        protected override void OpenedViewCommandExecute(object obj)
        {
            GetData();
        }
        protected override void RemoveItemCommandExecute(object obj)
        {
            if (RemoveItemCommandCanExecute(obj))
            {
                service.Delete(SelectedItem);
                GetData();
            }
        }
        protected override void EditItemCommandExecute(object obj)
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Address = this.SelectedItem.Address,
                FirstName = this.SelectedItem.FirstName,
                LastName = this.SelectedItem.LastName,
                Login = this.SelectedItem.Login,
                Password = this.SelectedItem.Password,
                Patronimic = this.SelectedItem.Patronimic,
                Phone = this.SelectedItem.Phone,
                UserType = this.SelectedItem.UserType
            };
            GetData();
        }
    }
}
