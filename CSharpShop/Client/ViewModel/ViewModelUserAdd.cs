using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Client.Component;

namespace Client.ViewModel
{
    public class ViewModelUserAdd : ViewModelAdd<User>
    {
        private readonly ServiceReferenceUser.IShopServiceBaseOf_User userService;
        public ViewModelUserAdd(ServiceReferenceUser.IShopServiceBaseOf_User userService)
        {
            this.userService = userService;
        }
        protected override bool AddItemCommandCanExecute(object obj)
        {
            return !(String.IsNullOrEmpty(this.Item.Phone) ||
                String.IsNullOrEmpty(this.Item.Login) ||
                String.IsNullOrEmpty(this.Item.Password));
        }
        protected override void AddItemCommandExecute(object obj)
        {
            userService.Create(Item);
            Messenger.Instance.Send("Adding of new User complete");
        }

    }
}
