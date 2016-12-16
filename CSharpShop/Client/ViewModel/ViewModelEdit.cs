using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Component;
using System.Windows.Input;

namespace Client.ViewModel
{
    public abstract class ViewModelEdit<T> : ViewModelBase<T> where T : class
    {
        protected RelayCommand editItemCommand;
        protected RelayCommand closeEditViewCommand;
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
        public virtual ICommand CloseEditViewCommand
        {
            get
            {
                if (closeEditViewCommand == null)
                {
                    closeEditViewCommand = new RelayCommand(CloseEditCommandExecute);
                }
                return closeEditViewCommand;
            }
        }
        protected virtual void CloseEditCommandExecute(object obj)
        {
            Messenger.Instance.Send("Edit view closed");
        }
        protected abstract bool EditItemCommandCanExecute(object obj);
        protected abstract void EditItemCommandExecute(object obj);
    }
}
