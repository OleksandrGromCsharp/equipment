using System.Windows.Input;

namespace equipment.Infrastructure.Commands.Base
{
    /// <summary>
    /// Базовий клас для команд
    /// </summary>
    internal abstract class CommandBase : ICommand
    {
        /// <summary>
        /// Відбувається, коли диспетчер команд виявляє зміну Об'єкт-ініціалізатор команди
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Можливість виконання команди
        /// </summary>
        /// <param name="parameter">Об'єкт-ініціалізатор команди</param>
        /// <returns>Значення: True - якщо команду можливо виконати; False - якщо команду не можливо виконати</returns>
        public abstract bool CanExecute(object? parameter);

        /// <summary>
        /// Бізнес логіка команди
        /// </summary>
        /// <param name="parameter">Об'єкт-ініціалізатор команди</param>
        public abstract void Execute(object? parameter);
    }
}
