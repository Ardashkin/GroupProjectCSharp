﻿using System;
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
        public override void GetData()
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
        protected override void RemoveItemCommandApply(bool isOk)
        {
            if (isOk)
            {
                shopService.Delete(SelectedItem);
                GetData();
            }
        }
        protected override void EditItemCommandExecute(object obj)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Description = this.SelectedItem.Description,
                ProductPriceId = this.SelectedItem.ProductPriceId,
                Title = this.SelectedItem.Title
            };
            Messenger.Instance.Send(product, "Edit Product view");
            GetData();
        }
    }
}
