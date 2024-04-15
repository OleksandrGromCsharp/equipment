using System.CodeDom;

using equipment.Entities;
using equipment.Entities.Base;
using equipment.ViewModels.Base;

namespace equipment.ViewModels
{
    class ComputerViewModel : EquipmentBaseViewModel
    {
        #region Свойства

        #region Equipment : ComputerEntity - Екземпляр типу комп'ютера

        private ComputerEntity _equipment = new();
        /// <summary>
        /// Екземпляр типу комп'ютера
        /// </summary>
        public ComputerEntity Equipment { get => _equipment; set => Set(ref _equipment, value); }

        #endregion

        #region SelectedTypeEquipment : EnumTypeComputer - Перелік типів комп'ютерів

        private readonly EnumTypeComputer _typeEquipment;
        /// <summary>
        /// Перелік типів комп'ютерів
        /// </summary>
        public EnumTypeComputer SelectedTypeEquipment { get => _typeEquipment; }

        #endregion
        
        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public ComputerViewModel(object entity)
        {
            IsVisibleMeasuredData = false;
            if(entity.GetType().ToString() == "equipment.Entities.ComputerEntity")
                Equipment = (ComputerEntity)entity;
        }

        /// <summary>
        /// Метод повернення екземпляра типу комп'ютери
        /// </summary>
        /// <returns>Екземпляр типу комп'ютери</returns>
        public override EquipmentBase GetEquipment() => _equipment;
    }
}
