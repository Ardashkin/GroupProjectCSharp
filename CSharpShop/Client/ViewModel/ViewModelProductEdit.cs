using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Component;
using DomainModel;

namespace Client.ViewModel
{
    public class ViewModelProductEdit : ViewModelEdit<Product>
    {
        private readonly ServiceReferenceProduct.IShopServiceBaseOf_Product productService;
        public ViewModelProductEdit(ServiceReferenceProduct.IShopServiceBaseOf_Product productService)
        {
            this.productService = productService;
        }
        protected override bool EditItemCommandCanExecute(object obj)
        {
            return !String.IsNullOrEmpty(this.SelectedItem.Title);
        }

        protected override void EditItemCommandExecute(object obj)
        {
            productService.Update(SelectedItem);
            Messenger.Instance.Send("Product edition complete");
        }
    }
}
