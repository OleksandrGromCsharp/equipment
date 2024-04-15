using System.ComponentModel;

namespace equipment.Entities
{
    enum EnumTypeEquipment
    {
        [Description("Технічне обладнання")] MachineryEntity = 4,
        [Description("Комп'ютери")] ComputerEntity = 1,
        [Description("Комп'ютерна периферія")] ComputerPeripheralsEntity = 2,
        [Description("Мережеве обладнання")] NetworkEquipmentEntity = 3
    }
}
