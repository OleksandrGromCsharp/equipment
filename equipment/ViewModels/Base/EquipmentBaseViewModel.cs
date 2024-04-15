using System.Windows.Input;

using equipment.Entities;
using equipment.Entities.Base;
using equipment.Infrastructure.Commands;

namespace equipment.ViewModels.Base
{
    internal class EquipmentBaseViewModel : ViewModelBase
    {
        #region Свойства

        #region Equipment : EquipmentBase - Екземпляр устаткування

        /// <summary>
        /// Екземпляр устаткування
        /// </summary>
        protected EquipmentBase Equipment { get; set; }

        #endregion

        #region Title : string - Текст заголовка вікна

        private string _title = "Створення нового устаткування";
        /// <summary>
        /// Текст заголовка вікна
        /// </summary>
        public string Title { get => _title; set => Set(ref _title, value); }

        #endregion

        #region TitleButtonOK : string - Текст кнопки DialogResult True

        private string _titleButtonOK = "Створити";
        /// <summary>
        /// Текст кнопки DialogResult True
        /// </summary>
        public string TitleButtonOK { get => _titleButtonOK; set => Set(ref _titleButtonOK, value); }

        #endregion

        #region TitleButtonCancel : string - Текст кнопки DialogResult False

        private string _titleButtonCancel = "Відмінити";
        /// <summary>
        /// Текст кнопки DialogResult False
        /// </summary>
        public string TitleButtonCancel { get => _titleButtonCancel; set => Set(ref _titleButtonCancel, value); }

        #endregion

        #region TitleGeneralData : string - Текст заголовка блоку загальних даних

        private string _titleGeneralData = "Загальні дані";
        /// <summary>
        /// Текст заголовка блоку загальних даних
        /// </summary>
        public string TitleGeneralData { get => _titleGeneralData; set => Set(ref _titleGeneralData, value); }

        #endregion

        #region TitleAccountingData : string - Текст заголовка блоку облікових даних

        private string _titleAccountingData = "Облікові дані";
        /// <summary>
        /// Текст заголовка блоку облікових даних
        /// </summary>
        public string TitleAccountingData { get => _titleAccountingData; set => Set(ref _titleAccountingData, value); }

        #endregion

        #region TitlePropertiesData : string - Текст заголовка блоку характеристик устаткування

        private string _titlePropertiesData = "Характеристики";
        /// <summary>
        /// Текст заголовка блоку характеристик устаткування
        /// </summary>
        public string TitlePropertiesData { get => _titlePropertiesData; set => Set(ref _titlePropertiesData, value); }

        #endregion

        #region TitleMetrologyPropertiesData : string - Текст заголовка блоку "Метрологічні характеристики"

        private string _titleMetrologyPropertiesData = "Метрологічні дані";
        /// <summary>
        /// Текст заголовка блоку "Метрологічні характеристики"
        /// </summary>
        public string TitleMetrologyPropertiesData { get => _titleMetrologyPropertiesData; set => Set(ref _titleMetrologyPropertiesData, value); }

        #endregion

        #region TitleTypeMechinery : string - Текст заголовка типу обладнання

        private string _titleTypeMechinery = "Тип обладнання";
        /// <summary>
        /// Текст заголовка типу обладнання
        /// </summary>
        public string TitleTypeMechinery { get => _titleTypeMechinery; set => Set(ref _titleTypeMechinery, value); }

        #endregion

        #region IsVisibleMeasuredData : bool - Наявність метрологічних характеристик обладнання

        private bool _isVisibleMeasuredData;
        /// <summary>
        /// Наявність метрологічних характеристик обладнання
        /// </summary>
        public bool IsVisibleMeasuredData { get => _isVisibleMeasuredData; set => Set(ref _isVisibleMeasuredData, value); }

        #endregion

        #region TitleTrademarkData : string - Текст заголовка торгової марка (фірми виробник) устаткування

        private string _titleTrademarkData = "Торгова марка (фірма виробник) устаткування";
        /// <summary>
        /// Текст заголовка торгової марка (фірми виробник) устаткування
        /// </summary>
        public string TitleTrademarkData { get => _titleTrademarkData; set => Set(ref _titleTrademarkData, value); }

        #endregion

        #region TitleModelData : string - Текст заголовка моделі устаткування

        private string _titleModelData = "Модель устаткування";
        /// <summary>
        /// Текст заголовка моделі устаткування
        /// </summary>
        public string TitleModelData { get => _titleModelData; set => Set(ref _titleModelData, value); }

        #endregion

        #region TitleInventaryNumberData : string - Текст заголовка інвентарного номера

        private string _titleInventaryNumberData = "Інвентарний номер";
        /// <summary>
        /// Текст заголовка інвентарного номера
        /// </summary>
        public string TitleInventaryNumberData { get => _titleInventaryNumberData; set => Set(ref _titleInventaryNumberData, value); }

        #endregion

        #region TitleFactoryNumberData : string - Текст заголовка заводського (серійного) номера

        private string _titleFactoryNumberData = "Заводський (серійний) номер";
        /// <summary>
        /// Текст заголовка заводського (серійного) номера
        /// </summary>
        public string TitleFactoryNumberData { get => _titleFactoryNumberData; set => Set(ref _titleFactoryNumberData, value); }

        #endregion

        #region TitleProducingCountryData : string - Текст заголовка країни виготовлення устаткування

        private string _titleProducingCountryData = "Країна виробник устаткування";
        /// <summary>
        /// Текст заголовка країни виготовлення устаткування
        /// </summary>
        public string TitleProducingCountryData { get => _titleProducingCountryData; set => Set(ref _titleProducingCountryData, value); }

        #endregion

        #region SelectedProducingCountry : EnumProducingCountry - Перелік країн виготовлення устаткування

        private readonly EnumProducingCountry _producingCountry;
        /// <summary>
        /// Перелік країн виготовлення устаткування
        /// </summary>
        public EnumProducingCountry SelectedProducingCountry { get => _producingCountry; }

        #endregion

        #region TitleNumberEquipmentData : string - Текст заголовка номера устаткування

        private string _titleNumberEquipmentData = "Номер устаткування";
        /// <summary>
        /// Текст заголовка номера устаткування
        /// </summary>
        public string TitleNumberEquipmentData { get => _titleNumberEquipmentData; set => Set(ref _titleNumberEquipmentData, value); }

        #endregion

        #region TitleDateOperationData : string - Текст заголовка дати введення в експлуатацію обладнання

        private string _titleDateOperationData = "Дата введення в експлуатацію";
        /// <summary>
        /// Текст заголовка дати введення в експлуатацію обладнання
        /// </summary>
        public string TitleDateOperationeData { get => _titleDateOperationData; set => Set(ref _titleDateOperationData, value); }

        #endregion

        #region TitleOperationNumberData : string - Текст заголовка номера акту введення в експлуатацію обладнання

        private string _titleOperationNumberData = "Номер акту введення в експлуатацію";
        /// <summary>
        /// Текст заголовка номера акту введення в експлуатацію обладнання
        /// </summary>
        public string TitleOperationNumberData { get => _titleOperationNumberData; set => Set(ref _titleOperationNumberData, value); }

        #endregion

        #region TitleInformationDocumentData : string - Текст заголовка наявності документації на устаткування

        private string _titleInformationDocumentData = "Документація на устаткування";
        /// <summary>
        /// Текст заголовка наявності документації на устаткування
        /// </summary>
        public string TitleInformationDocumentData { get => _titleInformationDocumentData; set => Set(ref _titleInformationDocumentData, value); }

        #endregion

        #region TitlePassportData : string - Текст заголовка наявності паспорту на устаткування

        private string _titlePassportData = "Паспорт на устаткування";
        /// <summary>
        /// Текст заголовка наявності паспорту на устаткування
        /// </summary>
        public string TitlePassportData { get => _titlePassportData; set => Set(ref _titlePassportData, value); }

        #endregion

        #region TitleInstructionEquipmentData : string - Текст заголовка наявності інструкції з експлуатації устаткування

        private string _titleInstructionEquipmentData = "Інструкція з експлуатації устаткування";
        /// <summary>
        /// Текст заголовка наявності інструкції з експлуатації устаткування
        /// </summary>
        public string TitleInstructionEquipmentData { get => _titleInstructionEquipmentData; set => Set(ref _titleInstructionEquipmentData, value); }

        #endregion

        #region TitleInstructionErrorData : string - Текст заголовка наявності інструкції дій персоналу під час збоїв та аварій обладнання

        private string _titleInstructionErrorData = "Інструкція дій персоналу під час збоїв та аварій обладнання";
        /// <summary>
        /// Текст заголовка наявності інструкції дій персоналу під час збоїв та аварій обладнання
        /// </summary>
        public string TitleInstructionErrorData { get => _titleInstructionErrorData; set => Set(ref _titleInstructionErrorData, value); }

        #endregion

        #region TitleConditionEquipmentData : string - Текст заголовка стану устаткування

        private string _titleConditionEquipmentData = "Стан устаткування";
        /// <summary>
        /// Текст заголовка стану устаткування
        /// </summary>
        public string TitleConditionEquipmentData { get => _titleConditionEquipmentData; set => Set(ref _titleConditionEquipmentData, value); }

        #endregion

        #region TitleIsNewConditionEquipmentData : string - Текст заголовка стану устаткування (нове устаткування)

        private string _titleIsNewConditionEquipmentData = "Нове устаткування";
        /// <summary>
        /// Текст заголовка стану устаткування (нове устаткування)
        /// </summary>
        public string TitleIsNewConditionEquipmentData { get => _titleIsNewConditionEquipmentData; set => Set(ref _titleIsNewConditionEquipmentData, value); }

        #endregion

        #region TitleIsNotNewConditionEquipmentData : string - Текст заголовка стану устаткування (вживане устаткування)

        private string _titleIsNotNewConditionEquipmentData = "Вживане устаткування";
        /// <summary>
        /// Текст заголовка стану устаткування (вживане устаткування)
        /// </summary>
        public string TitleIsNotNewConditionEquipmentData { get => _titleIsNotNewConditionEquipmentData; set => Set(ref _titleIsNotNewConditionEquipmentData, value); }

        #endregion

        #region TitlePurveyorEquipmentData : string - Текст заголовка постачальника устаткування

        private string _titlePurveyorEquipmentData = "Постачальник устаткування";
        /// <summary>
        /// Текст заголовка постачальника устаткування
        /// </summary>
        public string TitlePurveyorEquipmentData { get => _titlePurveyorEquipmentData; set => Set(ref _titlePurveyorEquipmentData, value); }

        #endregion

        #region TitleDateCreateData : string - Текст заголовка дати виготовлення устаткування

        private string _titleDateCreateData = "Дата виробництва";
        /// <summary>
        /// Текст заголовка дати виготовлення устаткування
        /// </summary>
        public string TitleDateCreateData { get => _titleDateCreateData; set => Set(ref _titleDateCreateData, value); }

        #endregion

        #region TitleDateDeliveryData : string - Текст заголовка дати придбання устаткування

        private string _titleDateDeliveryData = "Дата придбання";
        /// <summary>
        /// Текст заголовка дати придбання устаткування
        /// </summary>
        public string TitleDateDeliveryData { get => _titleDateDeliveryData; set => Set(ref _titleDateDeliveryData, value); }

        #endregion

        #region TitleInitialCostData : string - Текст заголовка первісної вартості устаткування

        private string _itleInitialCostData = "Первісна вартість устаткування";
        /// <summary>
        /// Текст заголовка первісної вартості устаткування
        /// </summary>
        public string TitleInitialCostData { get => _itleInitialCostData; set => Set(ref _itleInitialCostData, value); }

        #endregion

        #region TitleStatusEquipmentData : string - Текст заголовка статусу устаткування

        private string _titleStatusEquipmentData = "Статус устаткування";
        /// <summary>
        /// Текст заголовка статусу устаткування
        /// </summary>
        public string TitleStatusEquipmentData { get => _titleStatusEquipmentData; set => Set(ref _titleStatusEquipmentData, value); }

        #endregion

        #region SelectedStatusEquipment : EnumStatusEquipment - Перелік статусів устаткування

        private EnumStatusEquipment _statusEquipment;
        /// <summary>
        /// Перелік статусів устаткування
        /// </summary>
        public EnumStatusEquipment SelectedStatusEquipment { get => _statusEquipment; }

        #endregion

        #region TitleOperatingPermitData : string - Текст заголовка дозволу на експлуатацію устаткування

        private string _titleOperatingPermitData = "Дозвіл на експлуатацію устаткування";
        /// <summary>
        /// Текст заголовка дозволу на експлуатацію устаткування
        /// </summary>
        public string TitleOperatingPermitData { get => _titleOperatingPermitData; set => Set(ref _titleOperatingPermitData, value); }

        #endregion

        #region TitleIsOperatingPermitData : string - Текст заголовка наявність дозволу на експлуатацію устаткування

        private string _titleIsOperatingPermitData = "Наявність дозволу на експлуатацію від ГОВ";
        /// <summary>
        /// Текст заголовка наявність дозволу на експлуатацію устаткування
        /// </summary>
        public string TitleIsOperatingPermitData { get => _titleIsOperatingPermitData; set => Set(ref _titleIsOperatingPermitData, value); }

        #endregion

        #region TitleDateStatusEquipmentData : string - Текст заголовка дата введення статусу устаткування

        private string _titleDateStatusEquipmentData = "Дата введення статусу";
        /// <summary>
        /// Текст заголовка дата введення статусу устаткування
        /// </summary>
        public string TitleDateStatusEquipmentData { get => _titleDateStatusEquipmentData; set => Set(ref _titleDateStatusEquipmentData, value); }

        #endregion

        #region TitleLocationApartmentData : string - Текст заголовка кабінета розміщення устаткування

        private string _titleLocationApartmentData = "Номер приміщення";
        /// <summary>
        /// Текст заголовка кабінета розміщення устаткування
        /// </summary>
        public string TitleLocationApartmentData { get => _titleLocationApartmentData; set => Set(ref _titleLocationApartmentData, value); }

        #endregion

        #region TitleLocationUnitData : string - Текст заголовка відділу розміщення устаткування

        private string _titleLocationUnitData = "Відділ де розміщено устаткування";
        /// <summary>
        /// Текст заголовка відділу розміщення устаткування
        /// </summary>
        public string TitleLocationUnitData { get => _titleLocationUnitData; set => Set(ref _titleLocationUnitData, value); }

        #endregion

        #region SelectedLocationUnit : EnumUnit - Перелік відділів

        private EnumUnit _locationUnit;
        /// <summary>
        /// Перелік відділів
        /// </summary>
        public EnumUnit SelectedLocationUnit { get => _locationUnit; }

        #endregion

        #region TitleTehnicalPropertiesData : string - Текст заголовка блоку "Технічні характеристики"

        private string _titleTehnicalPropertiesData = "Технічні характеристики";
        /// <summary>
        /// Текст заголовка блоку "Технічні характеристики"
        /// </summary>
        public string TitleTehnicalPropertiesData { get => _titleTehnicalPropertiesData; set => Set(ref _titleTehnicalPropertiesData, value); }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        #region Команди

        #region OpenPassportEquipmentCommand - Відкриття файлу "Паспорт устаткування"

        /// <summary>
        /// Відкриття файлу "Паспорт устаткування"
        /// </summary>
        public ICommand OpenPassportEquipmentCommand { get; }

        private static bool CanOpenPassportEquipmentCommandExecuted(object p) => p is not null;

        private void OnOpenPassportEquipmentCommandExecuted(object p)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region OpenInstructionEquipmentCommand - Відкриття файлу "Інструкція з експлуатації устаткування"

        /// <summary>
        /// Відкриття файлу "Інструкція з експлуатації устаткування"
        /// </summary>
        public ICommand OpenInstructionEquipmentCommand { get; }

        private static bool CanOpenInstructionEquipmentCommandExecuted(object p) => p is not null;

        private void OnInstructionEquipmentCommandExecuted(object p)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region OpenInstructionErrorCommand - Відкриття файлу "Інструкція дій персоналу під час збоїв та аварій обладнання"

        /// <summary>
        /// Відкриття файлу "Інструкція дій персоналу під час збоїв та аварій обладнання"
        /// </summary>
        public ICommand OpenInstructionErrorCommand { get; }

        private static bool CanOpenInstructionErrorCommandExecuted(object p) => p is not null;

        private void OnInstructionErrorCommandExecuted(object p)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public EquipmentBaseViewModel()
        {
            #region Створення команд

            OpenPassportEquipmentCommand = new LambdaCommand(OnOpenPassportEquipmentCommandExecuted, CanOpenPassportEquipmentCommandExecuted);
            OpenInstructionEquipmentCommand = new LambdaCommand(OnInstructionEquipmentCommandExecuted, CanOpenInstructionEquipmentCommandExecuted);
            OpenInstructionErrorCommand = new LambdaCommand(OnInstructionErrorCommandExecuted, CanOpenInstructionErrorCommandExecuted);

            #endregion
        }

        /// <summary>
        /// Віртуальний метод повернення екземпляра устаткування типом EquipmentBase
        /// </summary>
        /// <returns>Екземпляр устаткування Equipment типу EquipmentBase</returns>
        public virtual EquipmentBase GetEquipment() => Equipment;
    }
}
