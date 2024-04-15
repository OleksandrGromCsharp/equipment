using System.Drawing;

using equipment.Entities.Base;

namespace equipment.Entities
{
    class NetworkEquipmentEntity : EquipmentBase
    {
        #region Свойства

        private EnumTypeNetworkEquipment _typeChild;
        /// <summary>
        /// Тип обладнання
        /// </summary>
        public EnumTypeNetworkEquipment TypeChild { get => _typeChild; set => Set(ref _typeChild, value); }

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public NetworkEquipmentEntity()
        {
            Icon = "\xE977";
            IconColorName = "ff2e8e0d";
        }
    }
}
