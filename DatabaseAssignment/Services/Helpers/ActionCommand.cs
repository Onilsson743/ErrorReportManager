using System;


namespace DatabaseAssignment.Services.Helpers
{
    public class ActionCommand : BaseCommand
    {
        private readonly Action<object> _action;
        private readonly Func<object, bool> _canExecute;

        public ActionCommand(Action<object> action, Func<object, bool> canExecute)
        {
            _action = action ?? throw new ArgumentNullException("action", "You must specify an action<T>");
            _canExecute = canExecute;
        }
        public override void Execute(object? parameter)
        {
            _action(parameter);
        }
    }
}
