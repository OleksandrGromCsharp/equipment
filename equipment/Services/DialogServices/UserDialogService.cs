using System.Windows;
using System.Drawing;

using equipment.Entities;
using equipment.Services.DialogService.Interface;
using equipment.Views.Windows;
using equipment.Infrastructure;
using equipment.ViewModels;
using System.Drawing;
using equipment.ViewModels.Base;
using equipment.Entities.Base;

namespace equipment.Services.DialogServices
{
    /// <summary>
    /// Діалогове вікно для WPF
    /// </summary>
    internal class UserDialogService : IDialogService
    {
        /// <summary>
        /// Діалоговий метод для підтвердження
        /// </summary>
        /// <param name="Message">Текст повідомлення</param>
        /// <param name="Caption">Заголовок</param>
        /// <param name="Exclamation">Попередження (true) : Запитання (false)</param>
        /// <returns></returns>
        public bool Confirm(string Message, string Caption, bool Exclamation = false) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.YesNo,
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
            == MessageBoxResult.Yes;

        /// <summary>
        /// Діалоговий метод для виведення помилки
        /// </summary>
        /// <param name="Message">Текст повідомлення</param>
        /// <param name="Caption">Заголовок</param>
        /// <returns></returns>
        public void ShowError(string Message, string Caption) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.OK,
                MessageBoxImage.Error);

        /// <summary>
        /// Діалоговий метод для виведення інформації
        /// </summary>
        /// <param name="Message">Текст повідомлення</param>
        /// <param name="Caption">Заголовок</param>
        /// <returns></returns>
        public void ShowInformation(string Message, string Caption) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.OK,
                MessageBoxImage.Information);

        /// <summary>
        /// Діалоговий метод для виведення попередження
        /// </summary>
        /// <param name="Message">Текст повідомлення</param>
        /// <param name="Caption">Заголовок</param>
        /// <returns></returns>
        public void ShowWarning(string Message, string Caption) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.OK,
                MessageBoxImage.Warning);

        /// <summary>
        /// Створення та запуск діалогових методів взаємодії з користувачем
        /// </summary>
        /// <param name="Variable">Екземпляр об'єкта, що надається для взаємодії</param>
        /// <param name="Parameters">Параметри, що необхідні. Default = null</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public bool Interaction(ref object Variable, object[] Parameters = null)
        {
            if (Variable is null)
            {
                ShowInformation(nameof(Variable), "equipment");
                return false;
            }

            /// Variable - екземпляр об'єкта устаткування
            /// Parameters[0] : bool - true створити новий екземпляр, false редагувати існуючий
            switch (Variable)
            {
                case EquipmentBase:

                    var selectedTypeEquipment = new Dictionary<string, EquipmentBaseViewModel>
                    {
                        { "equipment.Entities.MachineryEntity", new MachineryViewModel(Variable) },
                        { "equipment.Entities.ComputerEntity", new ComputerViewModel(Variable) },
                        { "equipment.Entities.ComputerPeripheralsEntity", new ComputerPeripheralsViewModel(Variable) },
                        { "equipment.Entities.NetworkEquipmentEntity", new NetworkEquipmentViewModel(Variable) }
                    };

                    if (selectedTypeEquipment.TryGetValue(Variable.GetType().ToString(), out EquipmentBaseViewModel viewModel))
                    {
                        if (!(bool)Parameters[0])
                        {
                            viewModel.Title = $"Редагувати \"{viewModel.GetEquipment().Trademark} {viewModel.GetEquipment().Model}\"";
                            viewModel.TitleButtonOK = "Змінити";
                        }

                        var equipmentMain = new MachineryMainWindow { DataContext = viewModel };
                        equipmentMain.ShowDialog();
                        if (equipmentMain.DialogResult == true)
                        {
                            viewModel.GetEquipment().Number = Generation.EquipmentNumber(
                                viewModel.GetEquipment().Type,
                                viewModel.GetEquipment().ProducingCountry,
                                viewModel.GetEquipment().InventoryNumber);

                            Variable = viewModel.GetEquipment();

                            return true;
                        }
                    }
                    else { ShowInformation(nameof(Variable), "equipment"); }
                    return false;
            }
            return false;    
        }
    }
}