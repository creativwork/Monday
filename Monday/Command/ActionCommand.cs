using System;
using System.Windows.Input;

namespace Monday.Command
{
    public class ActionCommand : ICommand
    {
        private bool isEnabled = true;
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                if (isEnabled == value)
                    return;

                isEnabled = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private readonly Action action;
        private readonly Action<object> actionObj;

        public ActionCommand(Action action) => this.action = action;
        public ActionCommand(Action<object> action) => this.actionObj = action;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => isEnabled;
        public void Execute(object parameter)
        {
            action?.Invoke();
            actionObj?.Invoke(parameter);
        }
    }
}