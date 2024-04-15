using System.ComponentModel;

namespace equipment.Entities
{
    enum EnumTypeNetworkEquipment
    {
        [Description("Маршрутизатор")] router = 1,
        [Description("Комутатор")] switchboard = 2,
        [Description("Модем")] modem = 3,
        [Description("wifi модем")] wifi_modem = 4,
        [Description("Міні АТС")] mini_ATS = 5
    }
}
