using System;
using System.Windows.Input;

namespace WPFDiaballik.Utilities
{
    /// <summary>
    /// Classs used to bind an action to a button.
    /// </summary>
    public class ButtonCommand<T> : ICommand
    {
        /// <summary>
        /// The action that will be executed.
        /// </summary>
        Action<T> execute = null;

        public ButtonCommand(Action<T> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(Object parameter)
        {
            execute((T)parameter);
        }
    }
}
