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
        protected abstract bool EditItemCommandCanExecute(object obj);
        protected abstract void EditItemCommandExecute(object obj);
    }
}
