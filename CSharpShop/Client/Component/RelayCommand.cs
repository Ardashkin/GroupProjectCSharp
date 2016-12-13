using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Component
{
    /// <summary>
    /// Class of delegating commands to the objects
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {            
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public RelayCommand(Action<object> execute) : this(execute, null){ }
        #region Implamentation of ICommand interface
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(object parameter)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("RelayCommand.execute");
            }
            execute(parameter);
        }
        #endregion
    }
}
