using System.ComponentModel;

namespace equipment.Entities
{
    enum EnumStatusEquipment
    {
        //Складське зберігання, експлуатація, на ремонті, зберігання, списання
        [Description("Експлуатація устаткування")] operation = 1,
        [Description("Складське зберігання устаткування")] warehouse_storage = 0,
        [Description("Списання устаткування")] withdrawal = 2,
        [Description("Устаткування на зберіганні")] storage = 3,
        [Description("Устаткування на ремонті")] under_repair = 4
    }
}
