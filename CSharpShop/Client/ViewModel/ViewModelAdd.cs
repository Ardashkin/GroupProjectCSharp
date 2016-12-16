using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Component;
using System.Windows.Input;

namespace Client.ViewModel
{
    public abstract class ViewModelAdd<T> : ViewModelBase<T> where T : class, new()
    {
        protected readonly T item;

        protected RelayCommand addItemCommand;
        protected RelayCommand closeAddViewCommand;

        public T Item
        {
            get { return item; }
        }
        public ViewModelAdd()
        {
            item = new T();
        }
        public virtual ICommand AddItemCommand
        {
            get
            {
                if (addItemCommand == null)
                {
                    addItemCommand = new RelayCommand(AddItemCommandExecute, AddItemCommandCanExecute);
                }
                return addItemCommand;
            }
        }
        public virtual ICommand CloseAddViewCommand
        {
            get
            {
                if (closeAddViewCommand == null)
                {
                    addItemCommand = new RelayCommand(CloseAddViewCommandExecute);
                }
                return addItemCommand;
            }
        }
        protected virtual void CloseAddViewCommandExecute(object obj)
        {
            Messenger.Instance.Send("Add view closed");
        }
        protected abstract bool AddItemCommandCanExecute(object obj);
        protected abstract void AddItemCommandExecute(object obj);
    }
}
