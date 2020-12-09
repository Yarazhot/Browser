using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Browser;

namespace WpfApp
{
    public class TypeCommand : ICommand
    {
        private event Action<ObjectType> renewParametersList;

        public TypeCommand(Action<ObjectType> action)
        {
            renewParametersList += action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
