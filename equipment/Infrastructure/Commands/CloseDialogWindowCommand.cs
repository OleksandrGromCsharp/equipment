using System;
using System.Windows;
using equipment.Infrastructure.Commands.Base;

namespace equipment.Infrastructure.Commands
{
    internal class CloseDialogWindowCommand : CommandBase
    {
        public bool? DialogResult { get; set; }

        public override bool CanExecute(object? parameter) => parameter is Window;

        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;
            if (parameter is null) return;

            var window = (Window)parameter;
            window.DialogResult = DialogResult;
            window.Close();
        }
    }
}
