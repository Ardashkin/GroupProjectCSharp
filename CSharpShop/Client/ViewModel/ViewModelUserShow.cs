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
        private readonly ServiceReferenceUser.IShopServiceBaseOf_User userService;
        public ViewModelUserShow(ServiceReferenceUser.IShopServiceBaseOf_User userService)
        {
            this.userService = userService;
        }
        public override void GetData()
        {
            Reset();
            foreach (var element in userService.GetItems())
            {
                obsCollection.Add(element);
            }
        }
        protected override void OpenViewCommandExecute(object obj)
        {
            Messenger.Instance.Send("Open User view");
            GetData();
        }
        protected override void OpenedViewCommandExecute(object obj)
        {
            GetData();
        }
        protected override void RemoveItemCommandApply(bool isOk)
        {
            if (isOk)
            {
                userService.Delete(SelectedItem);
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
            Messenger.Instance.Send(user, "Edit user view");
            GetData();
        }
    }
}
