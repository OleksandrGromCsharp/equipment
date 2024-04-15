using equipment.Entities.Interfaces;
using equipment.ViewModels.Base;

namespace equipment.Entities.Base
{
    internal class EquipmentBase : ViewModelBase, IEntities
    {
        private int _id;
        /// <summary>
        /// Унікальний ідентифікаційний номер
        /// </summary>
        public int Id { get => _id; set => Set(ref _id, value); }

        private string _number;
        /// <summary>
        /// Номер устаткування
        /// </summary>
        public string Number { get => _number; set => Set(ref _number, value); }

        private EnumTypeEquipment _type;
        /// <summary>
        /// Тип устаткування
        /// </summary>
        public EnumTypeEquipment Type { get => _type; set => Set(ref _type, value); }

        private string _trademark;
        /// <summary>
        /// Торгова марка (фірма виробник) устаткування 
        /// </summary>
        public string Trademark { get => _trademark; set => Set(ref _trademark, value); }

        private string _model;
        /// <summary>
        /// Модель устаткування
        /// </summary>
        public string Model { get => _model; set => Set(ref _model, value); }

        private EnumProducingCountry _producingCountry;
        /// <summary>
        /// Країна виробник устаткування
        /// </summary>
        public EnumProducingCountry ProducingCountry { get => _producingCountry; set => Set(ref _producingCountry, value); }

        private int _inventoryNumber;
        /// <summary>
        /// Інвентарний номер устаткування
        /// </summary>
        public int InventoryNumber { get => _inventoryNumber; set => Set(ref _inventoryNumber, value); }

        private string _factoryNumber;
        /// <summary>
        /// Заводський (серійний) номер устаткування
        /// </summary>
        public string FactoryNumber { get => _factoryNumber; set => Set(ref _factoryNumber, value); }

        private string _purveyor;
        /// <summary>
        /// Найменування постачальника устаткування
        /// </summary>
        public string Purveyor { get => _purveyor; set => Set(ref _purveyor, value); }

        private DateTime _deliveryDate = DateTime.Now;
        /// <summary>
        /// Дата постачання устаткування
        /// </summary>
        public DateTime DeliveryDate { get => _deliveryDate; set => Set(ref _deliveryDate, value); }

        private bool _isNewCondition;
        /// <summary>
        /// Стан устаткування (нове)
        /// </summary>
        public bool IsNewCondition { get => _isNewCondition; set => Set(ref _isNewCondition, value); }

        private bool _isOldCondition;
        /// <summary>
        /// Стан устаткування (вживане)
        /// </summary>
        public bool IsOldCondition { get => _isOldCondition; set => Set(ref _isOldCondition, value); }

        private DateTime _dateCreated = DateTime.Now;
        /// <summary>
        /// Дата випуску (виготовлення) устаткування
        /// </summary>
        public DateTime DateManufacture { get => _dateCreated; set => Set(ref _dateCreated, value); }

        private DateTime _dateOperation = DateTime.Now;
        /// <summary>
        /// Дата введення в експлуатацію устаткування
        /// </summary>
        public DateTime DateOperation { get => _dateOperation; set => Set(ref _dateOperation, value); }

        private string _operationNumber;
        /// <summary>
        /// Номер акту введення в експлуатацію устаткування
        /// </summary>
        public string OperationNumber { get => _operationNumber; set => Set(ref _operationNumber, value); }

        private int _apartment;
        /// <summary>
        /// Номер кабінету, в якому розміщене устаткування
        /// </summary>
        public int Apartment { get => _apartment; set => Set(ref _apartment, value); }

        private EnumUnit _unit;
        /// <summary>
        /// Структурний підрозділ, в якому знаходиться устаткування
        /// </summary>
        public EnumUnit Unit { get => _unit; set => Set(ref _unit, value); }

        private EnumStatusEquipment _status;
        /// <summary>
        /// Стан устаткування (Складське зберігання, експлуатація, на ремонті, зберігання, списання і т.п.)
        /// </summary>
        public EnumStatusEquipment Status { get => _status; set => Set(ref _status, value); }

        private DateTime _dateStatus = DateTime.Now;
        /// <summary>
        /// Дата набуття стану устаткування (Складське зберігання, експлуатація, на ремонті, зберігання, списання і т.п.)
        /// </summary>
        public DateTime DateStatus { get => _dateStatus; set => Set(ref _dateStatus, value); }

        private bool _isOperatingPermit;
        /// <summary>
        /// Наявність дозволу на експлуатацію
        /// </summary>
        public bool IsOperatingPermit { get => _isOperatingPermit; set => Set(ref _isOperatingPermit, value); }

        private bool _isPassport;
        /// <summary>
        /// Наявність паспорта устаткування
        /// </summary>
        public bool IsPassport { get => _isPassport; set => Set(ref _isPassport, value); }

        private string _pathPassport;
        /// <summary>
        /// Лінк на паспорт устаткування в електронному вигляді
        /// </summary>
        public string PathPassport { get => _pathPassport; set => Set( ref _pathPassport, value); }

        private bool _isInstruction;
        /// <summary>
        /// Наявність інструкції з експлуатації устаткування
        /// </summary>
        public bool IsInstruction { get => _isInstruction; set => Set(ref _isInstruction, value); }

        private string _pathInstruction;
        /// <summary>
        /// Лінк на інструкції з експлуатації устаткування в електронному вигляді
        /// </summary>
        public string PathInstruction { get => _pathInstruction; set => Set(ref _pathInstruction, value); }

        private bool _isInstructionError;
        /// <summary>
        /// Наявність інструкції дій персоналу під час збоїв та аварій обладнання
        /// </summary>
        public bool IsInstructionError { get => _isInstructionError; set => Set(ref _isInstructionError, value); }

        private string _pathInstructionError;
        /// <summary>
        /// Лінк на інструкцію дій персоналу під час збоїв та аварій обладнання в електронному вигляді
        /// </summary>
        public string PathInstructionError { get => _pathInstructionError; set => Set(ref _pathInstructionError, value); }

        private List<PropertiesEquipment> _propertiesData;
        /// <summary>
        /// Список технічних даних
        /// </summary>
        public List<PropertiesEquipment> PropertiesData { get => _propertiesData; set => Set(ref _propertiesData, value); }

        private string _icon;
        /// <summary>
        /// Іконка обладнання (шрифт Segoe MDL2 Assets)
        /// </summary>
        public string Icon { get => _icon; set => Set(ref _icon, value); }

        private string _iconColor;
        /// <summary>
        /// Колір іконки обладнання
        /// </summary>
        public string IconColorName { get => _iconColor; set => Set(ref _iconColor, value); }

        private bool _isMetrologicalData;
        /// <summary>
        /// Наявність метрологічних характеристик обладнання
        /// </summary>
        public bool IsMetrologicalData { get => _isMetrologicalData; set => Set(ref _isMetrologicalData, value); }

        private decimal _initialCost;
        /// <summary>
        /// Первісна вартість устаткування
        /// </summary>
        public decimal InitialCost { get => _initialCost; set => Set(ref _initialCost, value); }
    }
}
