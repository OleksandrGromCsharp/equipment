using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

using equipment.Entities;
using equipment.Entities.Base;
using equipment.Infrastructure.Commands;
using equipment.Services.DialogServices;
using equipment.Services.RepositoryServices;
using equipment.ViewModels.Base;

namespace equipment.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {

        #region Свойства

        #region Repositories

        private readonly List<EquipmentBase> listEquipment;

        private readonly RepositoryMemory<MachineryEntity> repositoryMachineryEntity = new();
        private readonly RepositoryMemory<ComputerEntity> repositoryComputerEntity = new();
        private readonly RepositoryMemory<ComputerPeripheralsEntity> repositoryComputerPeripheralEntity = new();
        private readonly RepositoryMemory<NetworkEquipmentEntity> repositoryNetworkEquipmentEntity = new();

        #endregion

        #region Title : string - Текст заголовка вікна

        private string _title = "Обладнання";
        /// <summary>
        /// Текст заголовка вікна
        /// </summary>
        public string Title { get => _title; set => Set(ref _title, value); }
        #endregion

        #region CloseButtonToolTip : string - Підказка кнопки закриття вікна

        private string _closeButtonToolTip = "Завершити роботу програми";
        /// <summary>
        /// Підказка кнопки закриття вікна
        /// </summary>
        public string CloseButtonToolTip { get => _closeButtonToolTip; set => Set(ref _closeButtonToolTip, value); }

        #endregion

        #region TitleChooseEquipment : string - Найменування зони вибору обладнання

        private string _titleChooseEquipment = "Перелік обладнання";
        /// <summary>
        /// Найменування зони вибору обладнання
        /// </summary>
        public string TitleChooseEquipment { get => _titleChooseEquipment; set => Set(ref _titleChooseEquipment, value); }

        #endregion

        #region TitleActionsEquipment : string - Найменування зони дій з обладнання

        private string _titleActionsEquipment = "Дії з устаткуванням";
        /// <summary>
        /// Найменування зони дій з обладнання
        /// </summary>
        public string TitleActionsEquipment { get => _titleActionsEquipment; set => Set(ref _titleActionsEquipment, value); }

        #endregion

        #region TitleCreateMachinery : string - Найменування дії створення екземпляра технологічного обладнання

        private string _titleCreateMachinery = "Технологічне обладнання";
        /// <summary>
        /// Найменування дії створення екземпляра технологічного обладнання
        /// </summary>
        public string TitleCreateMachinery { get => _titleCreateMachinery; set => Set(ref _titleCreateMachinery, value); }

        #endregion

        #region TitleCreateComputer : string - Найменування дії створення екземпляра комп'ютера

        private string _titleCreateComputer = "Комп'ютери";
        /// <summary>
        /// Найменування дії створення екземпляра комп'ютера
        /// </summary>
        public string TitleCreateComputer { get => _titleCreateComputer; set => Set(ref _titleCreateComputer, value); }

        #endregion

        #region TitleCreateComputerPeripherals : string - Найменування дії створення екземпляра комп'ютерної периферії

        private string _titleCreateComputerPeripherals = "Комп'ютерна периферія";
        /// <summary>
        /// Найменування дії створення екземпляра комп'ютерної периферії
        /// </summary>
        public string TitleCreateComputerPeripherals { get => _titleCreateComputerPeripherals; set => Set(ref _titleCreateComputerPeripherals, value); }

        #endregion

        #region TitleCreateNetworkEquipment : string - Найменування дії створення екземпляра мережевого обладнання

        private string _titleCreateNetworkEquipment = "Мережеве обладнання";
        /// <summary>
        /// Найменування дії створення екземпляра мережевого обладнання
        /// </summary>
        public string TitleCreateNetworkEquipment { get => _titleCreateNetworkEquipment; set => Set(ref _titleCreateNetworkEquipment, value); }

        #endregion

        #region ToolTipCreateMachinery : string - Підказка при створенні екземпляра обладнання

        private string _toolTipCreateMachinery = "Додати нове технологічне обладнання до бази даних";
        /// <summary>
        /// Підказка при створенні екземпляра обладнання
        /// </summary>
        public string ToolTipCreateMachinery { get => _toolTipCreateMachinery; set => Set(ref _toolTipCreateMachinery, value); }

        #endregion

        #region ToolTipCreateComputerPeripherals : string - Підказка при створенні екземпляра комп'ютерної периферії

        private string _toolTipCreateComputerPeripherals = "Додати комп'ютерну периферію до бази даних";
        /// <summary>
        /// Підказка при створенні екземпляра комп'ютерної периферії
        /// </summary>
        public string ToolTipCreateComputerPeripherals { get => _toolTipCreateComputerPeripherals; set => Set(ref _toolTipCreateComputerPeripherals, value); }

        #endregion

        #region ToolTipCreateComputer : string - Підказка при створенні екземпляра комп'ютера

        private string _toolTipCreateComputer = "Додати новий тип комп'ютера до бази даних";
        /// <summary>
        /// Підказка при створенні екземпляра комп'ютера
        /// </summary>
        public string ToolTipCreateComputer { get => _toolTipCreateComputer; set => Set(ref _toolTipCreateComputer, value); }

        #endregion

        #region ToolTipCreateNetworkEquipment : string - Підказка при створенні екземпляра мережевого обладнання

        private string _toolTipCreateNetworkEquipment = "Додати нове мережеве обладнання до бази даних";
        /// <summary>
        /// Підказка при створенні мережевого обладнання
        /// </summary>
        public string ToolTipCreateNetworkEquipment { get => _toolTipCreateNetworkEquipment; set => Set(ref _toolTipCreateNetworkEquipment, value); }

        #endregion

        #region TitleEditEquipment : string - Найменування дії редагування екземпляра обладнання

        private string _titleEditEquipment = "Редагувати устаткування";
        /// <summary>
        /// Найменування дії редагування екземпляра обладнання
        /// </summary>
        public string TitleEditEquipment { get => _titleEditEquipment; set => Set(ref _titleEditEquipment, value); }

        #endregion

        #region ToolTipEditEquipment : string - Підказка при редагуванні екземпляра обладнання

        private string _toolTipEditEquipment = "Змінити основну інформацію щодо вибраного устаткування";
        /// <summary>
        /// Підказка при редагуванні екземпляра обладнання
        /// </summary>
        public string ToolTipEditEquipment { get => _toolTipEditEquipment; set => Set(ref _toolTipEditEquipment, value); }

        #endregion

        #region TitleDeleteEquipment : string - Найменування дії видалення екземпляра обладнання

        private string _titleDeleteEquipment = "Видалити устаткування";
        /// <summary>
        /// Найменування дії видалення екземпляра обладнання
        /// </summary>
        public string TitleDeleteEquipment { get => _titleDeleteEquipment; set => Set(ref _titleDeleteEquipment, value); }

        #endregion

        #region ToolTipDeleteEquipment : string - Підказка при видаленні екземпляра обладнання

        private string _toolTipDeleteEquipment = "Видалити обране устаткування з бази даних підриємства";
        /// <summary>
        /// Підказка при видаленні екземпляра обладнання
        /// </summary>
        public string ToolTipDeleteEquipment { get => _toolTipDeleteEquipment; set => Set(ref _toolTipDeleteEquipment, value); }

        #endregion

        #region TitleProcessingEquipment : string - Найменування дії обробки екземпляра обладнання

        private string _titleProcessingEquipment = "Опрацювати устаткування";
        /// <summary>
        /// Найменування дії обробки екземпляра обладнання
        /// </summary>
        public string TitleProcessingEquipment { get => _titleProcessingEquipment; set => Set(ref _titleProcessingEquipment, value); }

        #endregion

        #region ToolTipProcessingEquipment : string - Підказка при обробці екземпляра обладнання

        private string _toolTipProcessingEquipment = "Внесення нових періодичних даних про вибране устаткування";
        /// <summary>
        /// Підказка при обробці екземпляра обладнання
        /// </summary>
        public string ToolTipProcessingEquipment { get => _toolTipProcessingEquipment; set => Set(ref _toolTipProcessingEquipment, value); }

        #endregion

        #region EquipmentCollectionView : ICollectionView - Представлення колекції обладнання

        private readonly CollectionViewSource _collectionViewSource = new();
        /// <summary>
        /// Представлення колекції обладнання
        /// </summary>
        public ICollectionView EquipmentCollectionView => _collectionViewSource.View;

        #endregion

        #region SelectEquipmentEntity : EquipmentBase - Вибраний екземпляр обладнання

        private EquipmentBase _selectEquipmentEntity;
        /// <summary>
        /// Вибраний екземпляр обладнання
        /// </summary>
        public EquipmentBase SelectEquipmentEntity { get => _selectEquipmentEntity; set => Set(ref _selectEquipmentEntity, value); }

        #endregion

        #region FilterText : string - Текст фільтра для обладнання

        private string _filterText;
        /// <summary>
        /// Текст фільтра для обладнання
        /// </summary>
        public string? FilterText
        {
            private get => _filterText;
            set
            {
                Set(ref _filterText, value);
                _collectionViewSource.View.Refresh();
            }
        }

        /// <summary>
        /// Фільтрація обладнання
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMailFiltred(object sender, FilterEventArgs e)
        {
            var filter_text = FilterText;
            if (string.IsNullOrWhiteSpace(filter_text))
                return;

            if (e.Item is not EquipmentBase equipmentBase)
            {
                e.Accepted = false;
                return;
            }

            if (equipmentBase.Model is null || equipmentBase.InventoryNumber is 0 || equipmentBase.Unit.ToString() is null)
            {
                e.Accepted = false;
                return;
            }

            if (equipmentBase.Trademark.Contains(filter_text, StringComparison.OrdinalIgnoreCase))
                return;
            if (equipmentBase.Model.Contains(filter_text, StringComparison.OrdinalIgnoreCase))
                return;
            if (equipmentBase.InventoryNumber.ToString().Contains(filter_text, StringComparison.OrdinalIgnoreCase))
                return;

            e.Accepted = false;
        }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        #region Команди

        #region CleanFindTextCommand - Очищення строки пошуку обладнання

        /// <summary>
        /// Очищення строки пошуку обладнання
        /// </summary>
        public ICommand CleanFindTextCommand { get; }

        private static bool CanCleanFindTextCommandExecuted(object p) => !string.IsNullOrEmpty((string)p);

        private void OnCleanFindTextCommandExecuted(object p) => FilterText = default;

        #endregion

        #region CreateMachineryCommand - Створення нового екземпляра технологічного обладнання

        /// <summary>
        /// Створення нового екземпляра технологічного обладнання
        /// </summary>
        public ICommand CreateMachineryCommand { get; }

        private void OnCreateMachineryCommandExecuted(object p)
        {
            object equipment = new MachineryEntity { Type = EnumTypeEquipment.MachineryEntity };
            if (!new UserDialogService().Interaction(ref equipment, [true]))
                return;
            if (equipment is null)
                return;
            
            try
            {
                repositoryMachineryEntity.Add((MachineryEntity)equipment);
                listEquipment.Add((MachineryEntity)equipment);
                _collectionViewSource.View.Refresh();
            }
            catch (Exception ex) { new UserDialogService().ShowInformation(ex.Message, ex.Source); }            
        }

        #endregion

        #region CreateComputerCommand - Створення нового екземпляра ком'ютера

        /// <summary>
        /// Створення нового екземпляра ком'ютера
        /// </summary>
        public ICommand CreateComputerCommand { get; }

        private void OnCreateComputerCommandExecuted(object p)
        {
            object equipment = new ComputerEntity { Type = EnumTypeEquipment.ComputerEntity };
            if (!new UserDialogService().Interaction(ref equipment, [true]))
                return;
            if (equipment is null)
                return;

            try
            {
                repositoryComputerEntity.Add((ComputerEntity)equipment);
                listEquipment.Add((ComputerEntity)equipment);
                _collectionViewSource.View.Refresh();
            }
            catch (Exception ex) { new UserDialogService().ShowInformation(ex.Message, ex.Source); }
        }

        #endregion

        #region CreateComputerPeripheralsCommand - Створення нового екземпляра комп'ютерної периферії

        /// <summary>
        /// Створення нового екземпляра комп'ютерної периферії
        /// </summary>
        public ICommand CreateComputerPeripheralsCommand { get; }

        private void OnCreateComputerPeripheralsCommandExecuted(object p)
        {
            object equipment = new ComputerPeripheralsEntity { Type = EnumTypeEquipment.ComputerPeripheralsEntity };
            if (!new UserDialogService().Interaction(ref equipment, [true]))
                return;
            if (equipment is null)
                return;

            try
            {
                repositoryComputerPeripheralEntity.Add((ComputerPeripheralsEntity)equipment);
                listEquipment.Add((ComputerPeripheralsEntity)equipment);
                _collectionViewSource.View.Refresh();
            }
            catch (Exception ex) { new UserDialogService().ShowInformation(ex.Message, ex.Source); }
        }

        #endregion

        #region CreateNetworkEquipmentCommand - Створення нового екземпляра мережевого обладнання

        /// <summary>
        /// Створення нового екземпляра мережевого обладнання
        /// </summary>
        public ICommand CreateNetworkEquipmentCommand { get; }

        private void OnCreateNetworkEquipmentCommandExecuted(object p)
        {
            object equipment = new NetworkEquipmentEntity { Type = EnumTypeEquipment.NetworkEquipmentEntity };
            if (!new UserDialogService().Interaction(ref equipment, [true]))
                return;
            if (equipment is null)
                return;

            try
            {
                repositoryNetworkEquipmentEntity.Add((NetworkEquipmentEntity)equipment);
                listEquipment.Add((NetworkEquipmentEntity)equipment);
                _collectionViewSource.View.Refresh();
            }
            catch (Exception ex) { new UserDialogService().ShowInformation(ex.Message, ex.Source); }
        }

        #endregion

        #region EditEquipmentsCommand - Редагування обраного екземпляра обладнання

        /// <summary>
        /// Редагування обраного екземпляра обладнання
        /// </summary>
        public ICommand EditEquipmentsCommand { get; }

        private static bool CanEditEquipmentCommandExecuted(object p) => p is EquipmentBase;

        private void OnEditEquipmentsCommandExecuted(object p)
        {
            object equipment = SelectEquipmentEntity;
            if (!new UserDialogService().Interaction(ref equipment, [false]))
                return;
            if (equipment is null)
                return;

            try
            {
                switch (SelectEquipmentEntity)
                {
                    case MachineryEntity:
                        repositoryMachineryEntity.Update(SelectEquipmentEntity.Id, (MachineryEntity)equipment);
                        _collectionViewSource.View.Refresh();
                        break;
                    case ComputerEntity:
                        repositoryComputerEntity.Update(SelectEquipmentEntity.Id, (ComputerEntity)equipment);
                        _collectionViewSource.View.Refresh();
                        break;
                    case ComputerPeripheralsEntity:
                        repositoryComputerPeripheralEntity.Update(SelectEquipmentEntity.Id, (ComputerPeripheralsEntity)equipment);
                        _collectionViewSource.View.Refresh();
                        break;
                    case NetworkEquipmentEntity:
                        repositoryNetworkEquipmentEntity.Update(SelectEquipmentEntity.Id, (NetworkEquipmentEntity)equipment);
                        _collectionViewSource.View.Refresh();
                        break;
                }
            }
            catch (ArgumentNullException ex) { new UserDialogService().ShowInformation($"{ex.Message}\n\n{ex.StackTrace}", ex.Source); }
            catch (ArgumentOutOfRangeException ex) { new UserDialogService().ShowInformation($"{ex.Message}\n\n{ex.StackTrace}", ex.Source); }
            catch (ArgumentException ex) { new UserDialogService().ShowInformation($"{ex.Message}\n\n{ex.StackTrace}", ex.Source); }
            catch (Exception ex) { new UserDialogService().ShowInformation($"{ex.Message}\n\n{ex.StackTrace}", ex.Source); }
        }

        #endregion

        #region DeleteEquipmentCommand - Видалення обраного екземпляра обладнання

        /// <summary>
        /// Видалення обраного екземпляра обладнання
        /// </summary>
        public ICommand DeleteEquipmentCommand { get; }

        private static bool CanDeleteEquipmentCommandExecuted(object p) => p is EquipmentBase;

        private void OnDeleteEquipmentCommandExecuted(object p)
        {
            try
            {
                switch (SelectEquipmentEntity)
                {
                    case MachineryEntity:
                        repositoryMachineryEntity.Remove(SelectEquipmentEntity.Id);
                        break;
                    case ComputerEntity:
                        repositoryComputerEntity.Remove(SelectEquipmentEntity.Id);
                        break;
                    case ComputerPeripheralsEntity:
                        repositoryComputerPeripheralEntity.Remove(SelectEquipmentEntity.Id);
                        break;
                    case NetworkEquipmentEntity:
                        repositoryNetworkEquipmentEntity.Remove(SelectEquipmentEntity.Id);
                        break;
                }
                listEquipment.Remove(SelectEquipmentEntity);
                _collectionViewSource.View.Refresh();
            }
            catch (ArgumentOutOfRangeException ex) { new UserDialogService().ShowInformation($"{ex.Message}\n\n{ex.StackTrace}", ex.Source); }
            catch (Exception ex) { new UserDialogService().ShowInformation($"{ex.Message}\n\n{ex.StackTrace}", ex.Source); }
        }

        #endregion

        #region ProcessingEquipmentCommand - Робота із вибраним екземпляром обладнання

        /// <summary>
        /// Робота із вибраним екземпляром обладнання
        /// </summary>
        public ICommand ProcessingEquipmentCommand { get; }

        private static bool CanProcessingEquipmentCommandExecuted(Object p) => p is EquipmentBase;

        private void OnProcessingEquipmentCommandExecuted(object p)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public MainViewModel()
        {

            #region Помилки при зчитуванні бази даних

            string? exceptionMessageError = null;

            if (repositoryMachineryEntity.exception is not null)
                exceptionMessageError += $"\n- Технологічного обладнання: \"{repositoryMachineryEntity.exception}\"";
            if (repositoryComputerEntity.exception is not null)
                exceptionMessageError += $"\n- Комп'ютери: \"{repositoryComputerEntity.exception}\"";
            if (repositoryComputerPeripheralEntity.exception is not null)
                exceptionMessageError += $"\n- Комп'ютерна периферія: \"{repositoryComputerPeripheralEntity.exception}\"";
            if (repositoryNetworkEquipmentEntity.exception is not null)
                exceptionMessageError += $"\n- Мережеве обладнання: \"{repositoryNetworkEquipmentEntity.exception}\"";
            if (exceptionMessageError is not null)
                new UserDialogService().ShowError($"Пошкоджена або відсутня база даних:{exceptionMessageError}", "equipment");

            string ? exceptionMessageInfo = null;
            if (!repositoryMachineryEntity.GetAll().Any())
                exceptionMessageInfo += "\n- Технологічного обладнання";
            if (!repositoryComputerEntity.GetAll().Any())
                exceptionMessageInfo += "\n- Комп'ютери";
            if (!repositoryComputerPeripheralEntity.GetAll().Any())
                exceptionMessageInfo += "\n- Комп'ютерна периферія";
            if (!repositoryNetworkEquipmentEntity.GetAll().Any())
                exceptionMessageInfo += "\n- Мережеве обладнання";
            if (exceptionMessageError is not null)
                new UserDialogService().ShowInformation($"Відсутні записи в базі даних:{exceptionMessageInfo}", "equipment");

            #endregion

            #region Організація CollectionView

            listEquipment =
                [
                .. repositoryMachineryEntity.GetAll(),
                .. repositoryComputerEntity.GetAll(),
                .. repositoryComputerPeripheralEntity.GetAll(),
                .. repositoryNetworkEquipmentEntity.GetAll()
                ];

            _collectionViewSource.Source = listEquipment.OrderBy(e => e.InventoryNumber);
            _collectionViewSource.Filter += OnMailFiltred;
            _collectionViewSource.GroupDescriptions.Add(new PropertyGroupDescription("Unit"));

            #endregion

            #region Створення команд

            CleanFindTextCommand = new LambdaCommand(OnCleanFindTextCommandExecuted, CanCleanFindTextCommandExecuted);
            CreateMachineryCommand = new LambdaCommand(OnCreateMachineryCommandExecuted);
            CreateComputerCommand = new LambdaCommand(OnCreateComputerCommandExecuted);
            CreateComputerPeripheralsCommand = new LambdaCommand(OnCreateComputerPeripheralsCommandExecuted);
            CreateNetworkEquipmentCommand = new LambdaCommand(OnCreateNetworkEquipmentCommandExecuted);
            EditEquipmentsCommand = new LambdaCommand(OnEditEquipmentsCommandExecuted, CanEditEquipmentCommandExecuted);
            DeleteEquipmentCommand = new LambdaCommand(OnDeleteEquipmentCommandExecuted, CanDeleteEquipmentCommandExecuted);
            ProcessingEquipmentCommand = new LambdaCommand(OnProcessingEquipmentCommandExecuted, CanProcessingEquipmentCommandExecuted);

            #endregion

        }
    }
}
