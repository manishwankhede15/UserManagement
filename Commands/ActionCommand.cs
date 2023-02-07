using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_User_Management.Commands
{
    public class ActionCommand : BaseCommand
    {
        private readonly Action<object> _action;
        private readonly Func<bool>? _canExecute;

        public ActionCommand(Action<object> action, Func<bool>? canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
                return base.CanExecute(parameter);
            return _canExecute();
        }

        public override void Execute(object? parameter)
        {
            _action(parameter);
        }
    }
}
