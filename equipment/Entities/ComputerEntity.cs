using System.Drawing;

using equipment.Entities.Base;

namespace equipment.Entities
{
    class ComputerEntity : EquipmentBase
    {
        #region Свойства

        private EnumTypeComputer _typeChild;
        /// <summary>
        /// Тип обладнання
        /// </summary>
        public EnumTypeComputer TypeChild { get => _typeChild; set => Set(ref _typeChild, value); }

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public ComputerEntity()
        {
            Icon = "\xF71E";
            IconColorName = "ff127cb3";
        }
    }
}
