using System.ComponentModel;

namespace equipment.Entities
{
    enum EnumTypeComputerPeripherals
    {
        [Description("Термінал")] terminal = 1,
        [Description("Принтер")] printer = 2,
        [Description("Термо-принтер")] thermal_printer = 3,
        [Description("Сканер")] scanner = 4,
        [Description("Сканер штрихкоду")] bar_code_scanner = 5,
        [Description("Джерело безперебійного живлення (UPS)")] ups = 6,
        [Description("Проектор")] proector = 7,
        [Description("Клавіатура")] keyboard = 8,
        [Description("Комп'ютерна миша")] mouse = 9,
        [Description("Монітор")] monitor = 10,
        [Description("Багатофункціональний принтер")] multifunction_printer = 11
    }
}
