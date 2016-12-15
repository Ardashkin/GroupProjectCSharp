using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Client.Component;
using System.Windows.Input;

namespace Client.ViewModel
{
    public class ViewModelProductShow : ViewModelShow<Product>
    {
        private readonly ServiceReferenceProduct.IShopServiceBaseOf_Product shopService;

        public ViewModelProductShow(ServiceReferenceProduct.IShopServiceBaseOf_Product shopService)
        {
            this.shopService = shopService;
        }
        public void GetData()
        {
            Reset();
            foreach (var element in shopService.GetItems())
            {
                obsCollection.Add(element);
            }
        }
        protected override void OpenViewCommandExecute(object obj)
        {
            Messenger.Instance.Send("Open Product view");
            GetData();
        }
        protected override void OpenedViewCommandExecute(object obj)
        {
            GetData();
        }

        protected override void RemoveItemCommandExecute(object obj)
        {
            Messenger.Instance.Send(new Action<bool>(RemoveItemCommandApply), "RemoveItemCommandApply");
        }
        protected override void RemoveItemCommandApply(bool isOk)
        {
            if (isOk)
            {
                shopService.Delete(SelectedItem);
                GetData();
            }
        }
    }
}
