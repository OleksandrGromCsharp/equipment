using equipment.Entities;
using equipment.Entities.Base;
using equipment.ViewModels.Base;

namespace equipment.ViewModels
{
    class NetworkEquipmentViewModel : EquipmentBaseViewModel
    {
        #region Свойства

        #region Equipment : NetworkEquipmentEntity - Екземпляр мережевого обладнання

        private NetworkEquipmentEntity _equipment = new();
        /// <summary>
        /// Екземпляр мережевого обладнання
        /// </summary>
        public NetworkEquipmentEntity Equipment { get => _equipment; set => Set(ref _equipment, value); }

        #endregion

        #region SelectedTypeEquipment : EnumTypeNetworkEquipment - Перелік типів мережевого обладнання

        private EnumTypeNetworkEquipment _typeEquipment;
        /// <summary>
        /// Перелік типів мережевого обладнання
        /// </summary>
        public EnumTypeNetworkEquipment SelectedTypeEquipment { get => _typeEquipment; }

        #endregion

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public NetworkEquipmentViewModel(object entity)
        {
            IsVisibleMeasuredData = true;
            if (entity.GetType().ToString() == "equipment.Entities.NetworkEquipmentEntity")
                Equipment = (NetworkEquipmentEntity)entity;
        }/// <summary>
         /// Метод повернення екземпляра мережевого обладнання
         /// </summary>
         /// <returns>Екземпляр мережевого обладнання</returns>
        public override EquipmentBase GetEquipment() => _equipment;
    }
}
