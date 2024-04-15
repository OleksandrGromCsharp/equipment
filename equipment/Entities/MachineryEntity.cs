using equipment.Entities.Base;


namespace equipment.Entities
{
    internal class MachineryEntity : EquipmentBase
    {
        #region Свойства

        private List<PropertiesEquipment> _metrologicalData;
        /// <summary>
        /// Метрологічні характеристики
        /// </summary>
        public List<PropertiesEquipment> MetrologicalData { get => _metrologicalData; set => Set(ref _metrologicalData, value); }

        private EnumTypeMachinery _typeChild;
        /// <summary>
        /// Тип обладнання
        /// </summary>
        public EnumTypeMachinery TypeChild { get => _typeChild; set => Set(ref _typeChild, value); }

        #endregion

        /*----------------------------------------------------------------------------------------------------------------------------------*/

        public MachineryEntity()
        {
            IsMetrologicalData = true;
            Icon = "\xF8B0";
            IconColorName = "ff88080e";
        }
    }
}
