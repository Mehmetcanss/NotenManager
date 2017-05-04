using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotenManager.DataModels
{
    class RCommand : ICommand
    {

        Action executeDelegate;
        Func<bool> canExecuteDelegate;
         
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RCommand(Action execDel, Func<bool> canExec)
        {
            this.executeDelegate = execDel;
            this.canExecuteDelegate = canExec;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteDelegate();
        }

        public void Execute(object parameter)
        {
            executeDelegate();
        }
    }
}
