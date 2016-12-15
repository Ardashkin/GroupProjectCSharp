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
        public ViewModelBase()
        {
            obsCollection = new ObservableCollection<T>();
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
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion      
    }
}
