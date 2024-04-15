using equipment.Entities;
using equipment.Entities.Base;
using equipment.ViewModels.Base;

namespace equipment.ViewModels
{
    class MachineryViewModel : EquipmentBaseViewModel
    {
        #region Свойства

        #region equipment : machineryentity - екземпляр технологічного обладнання

        private MachineryEntity _equipment = new();
        /// <summary>
        /// екземпляр типу комп'ютера
        /// </summary>
        public MachineryEntity Equipment { get => _equipment; set => Set(ref _equipment, value); }

        #endregion

        #region SelectedTypeEquipment : EnumTypeMachinery - Перелік типів технологічного обладнання

        private readonly EnumTypeMachinery _typeEquipment;
        /// <summary>
        /// Перелік типів технологічного обладнання
        /// </summary>
        public EnumTypeMachinery SelectedTypeEquipment { get => _typeEquipment; }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public MachineryViewModel(object entity)
        {
            IsVisibleMeasuredData = true;
            if (entity.GetType().ToString() == "equipment.Entities.MachineryEntity")
                Equipment = (MachineryEntity)entity;
        }

        /// <summary>
        /// Метод повернення екземпляра технологічного обладнання
        /// </summary>
        /// <returns>Екземпляр технологічного обладнання</returns>
        public override EquipmentBase GetEquipment() => _equipment;
    }
}
