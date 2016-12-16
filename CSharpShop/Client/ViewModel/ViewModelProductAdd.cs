using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Component;
using DomainModel;

namespace Client.ViewModel
{
    public class ViewModelProductAdd : ViewModelAdd<Product>
    {
        private readonly ServiceReferenceProduct.IShopServiceBaseOf_Product productService;
        public ViewModelProductAdd(ServiceReferenceProduct.IShopServiceBaseOf_Product productService)
        {
            this.productService = productService;
        }
        protected override bool AddItemCommandCanExecute(object obj)
        {
            return !String.IsNullOrEmpty(this.Item.Title);
        }
        protected override void AddItemCommandExecute(object obj)
        {
            productService.Create(Item);
        }
    }
}
