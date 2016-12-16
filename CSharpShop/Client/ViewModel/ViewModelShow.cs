using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Component;

namespace Client.ViewModel
{
    public abstract class ViewModelShow<T> : ViewModelBase<T> where T : class
    {
        protected RelayCommand openViewCommand;
        protected RelayCommand openedViewCommand;
        protected RelayCommand removeItemCommand;
        protected RelayCommand editItemCommand;

        public virtual ICommand OpenViewCommand
        {
            get
            {
                if (openViewCommand == null)
                {
                    openViewCommand = new RelayCommand(OpenViewCommandExecute);
                }
                return openViewCommand;
            }
        }
        public virtual ICommand OpenedViewCommand
        {
            get
            {
                if (openedViewCommand == null)
                {
                    openedViewCommand = new RelayCommand(OpenedViewCommandExecute);
                }
                return openedViewCommand;
            }
        }
        public virtual ICommand RemoveItemCommand
        {
            get
            {
                if (removeItemCommand == null)
                {
                    removeItemCommand = new RelayCommand(RemoveItemCommandExecute, RemoveItemCommandCanExecute);
                }
                return removeItemCommand;
            }
        }
        public virtual ICommand EditItemCommand
        {
            get
            {
                if (editItemCommand == null)
                {
                    editItemCommand = new RelayCommand(EditItemCommandExecute, EditItemCommandCanExecute);
                }
                return editItemCommand;
            }
        }
        protected virtual bool EditItemCommandCanExecute(object obj)
        {
            return selectedItem != default(T);
        }
        protected virtual bool RemoveItemCommandCanExecute(object obj)
        {
            return selectedItem != default(T);
        }
        public abstract void GetData();
        protected abstract void OpenViewCommandExecute(object obj);
        protected abstract void EditItemCommandExecute(object obj);
        protected abstract void OpenedViewCommandExecute(object obj);
        protected abstract void RemoveItemCommandExecute(object obj);
    }
}
