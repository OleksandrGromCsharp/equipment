using System.ComponentModel;

namespace equipment.Entities
{
    enum EnumTypeComputer
    {
        [Description("Персональний комп'ютер")] computer = 1,
        [Description("Сервер")] server = 2,
        [Description("Ноутбук")] laptop = 3,
        [Description("Системний блок")] system_unit = 4
    }
}
