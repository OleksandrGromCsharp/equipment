using System;
using equipment.Infrastructure.Commands.Base;

namespace equipment.Infrastructure.Commands
{
    internal class LambdaCommand : CommandBase
    {
        /// <summary>
        /// (Делегат) Об'єкст-ініціалізатор команди
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// (Делегат) Значення можливості виконання команди
        /// </summary>
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Конструктор виконання команди
        /// </summary>
        /// <param name="execute">(Делегат) Об'єкст-ініціалізатор команди</param>
        /// <param name="canExecute">(Делегат) Значення можливості виконання команди</param>
        /// <exception cref="ArgumentNullException"></exception>
        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Можливість виконання команди
        /// </summary>
        /// <param name="parameter">Об'єкт-ініціалізатор команди</param>
        /// <returns>Значення: True - якщо команду можливо виконати; False - якщо команду не можливо виконати</returns>
        public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Бізнес логіка команди
        /// </summary>
        /// <param name="parameter">Об'єкт-ініціалізатор команди</param>
        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;
            _execute(parameter);
        }
    }
}
