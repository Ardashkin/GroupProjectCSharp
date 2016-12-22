using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Client.Component;
using System.Windows.Input;

namespace Client.ViewModel
{
    public abstract class ViewModelBase<T> : INotifyPropertyChanged where T : class
    {
        protected readonly ObservableCollection<T> obsCollection;
        protected T selectedItem;

        protected readonly ServiceReference.IShopServiceBaseOf_BaseModel service;
        public ViewModelBase()
        {
            obsCollection = new ObservableCollection<T>();
            this.service = new ServiceReference.ShopServiceBaseOf_BaseModelClient();
        }

        public virtual ObservableCollection<T> ObsCollection
        {
            get { return obsCollection; }
        }
        public T SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(this.SelectedItem));
            }
        }
        protected virtual void Reset()
        {
            obsCollection.Clear();
        }
        #region Implementation of INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion      
    }
}
