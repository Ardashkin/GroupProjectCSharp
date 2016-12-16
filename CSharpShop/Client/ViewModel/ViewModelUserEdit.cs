using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Client.Component;

namespace Client.ViewModel
{
    public class ViewModelUserEdit : ViewModelEdit<User>
    {
        private readonly ServiceReferenceUser.IShopServiceBaseOf_User userService;
        public ViewModelUserEdit(ServiceReferenceUser.IShopServiceBaseOf_User userService)
        {
            this.userService = userService;
        }

        protected override bool EditItemCommandCanExecute(object obj)
        {
            return !(String.IsNullOrEmpty(this.SelectedItem.Phone) ||
                String.IsNullOrEmpty(this.SelectedItem.Login) ||
                String.IsNullOrEmpty(this.SelectedItem.Password));
        }

        protected override void EditItemCommandExecute(object obj)
        {
            userService.Update(SelectedItem);
            Messenger.Instance.Send("User edition complete");
        }
    }
}
