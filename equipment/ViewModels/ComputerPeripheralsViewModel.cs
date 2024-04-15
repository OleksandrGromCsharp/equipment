using equipment.Entities;
using equipment.Entities.Base;
using equipment.ViewModels.Base;

namespace equipment.ViewModels
{
    class ComputerPeripheralsViewModel : EquipmentBaseViewModel
    {
        #region Свойства

        #region Equipment : ComputerPeripheralsEntity - Екземпляр типу ком'ютерної перифірії

        private ComputerPeripheralsEntity _equipment = new();
        /// <summary>
        /// Екземпляр типу ком'ютерної перифірії
        /// </summary>
        public ComputerPeripheralsEntity Equipment { get => _equipment; set => Set(ref _equipment, value); }

        #endregion

        #region SelectedTypeComputerPeripherals : EnumTypeComputerPeripherals - Перелік типів ком'ютерної перифірії

        private readonly EnumTypeComputerPeripherals _typeEquipment;
        /// <summary>
        /// Перелік типів ком'ютерної перифірії
        /// </summary>
        public EnumTypeComputerPeripherals SelectedTypeEquipment { get => _typeEquipment; }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public ComputerPeripheralsViewModel(object entity)
        {
            IsVisibleMeasuredData = false;
            if (entity.GetType().ToString() == "equipment.Entities.ComputerPeripheralsEntity")
                Equipment = (ComputerPeripheralsEntity)entity;
        }

        /// <summary>
        /// Метод повернення екземпляра комп'ютерної периферії
        /// </summary>
        /// <returns>Екземпляр комп'ютерної периферії</returns>
        public override EquipmentBase GetEquipment() => _equipment;
    }
}
