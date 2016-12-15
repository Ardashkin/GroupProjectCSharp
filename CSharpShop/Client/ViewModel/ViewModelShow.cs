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
        protected abstract void OpenViewCommandExecute(object obj);

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
        protected abstract void OpenedViewCommandExecute(object obj);

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
        protected virtual bool RemoveItemCommandCanExecute(object obj)
        {
            return selectedItem != default(T);
        }
        protected abstract void RemoveItemCommandExecute(object obj);
        protected abstract void RemoveItemCommandApply(bool flag);
    }
}
