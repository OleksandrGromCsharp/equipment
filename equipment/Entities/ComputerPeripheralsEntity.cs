using System.Drawing;

using equipment.Entities.Base;

namespace equipment.Entities
{
    class ComputerPeripheralsEntity : EquipmentBase
    {
        #region Свойства

        private EnumTypeComputerPeripherals _typeChild;
        /// <summary>
        /// Тип обладнання
        /// </summary>
        public EnumTypeComputerPeripherals TypeChild { get => _typeChild; set => Set(ref _typeChild, value); }

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public ComputerPeripheralsEntity()
        {
            Icon = "\xEA6C";
            IconColorName = "ffbf4b08";
        }
    }
}
