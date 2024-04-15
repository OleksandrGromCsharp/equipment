using System.ComponentModel;

namespace equipment.Entities
{
    enum EnumTypeMachinery
    {
        [Description("Аквадистилятор")] water_distiller = 33,
        [Description("Аналізатор")] parser = 1,
        [Description("Аналізатор гематологічний")] hematological_analyzer = 2,
        [Description("Аналізатор гемоглобіну")] hemoglobin_analyzer = 3,
        [Description("Аналізатор імуноферментний")] immunoenzymatic_analyzer = 4,
        [Description("Апарат для відбору крові та її компонентів")] device_blood_sampling = 5,
        [Description("Баня водяна")] water_bath = 6,
        [Description("Бокс для стерильних робіт")] boxing_sterile = 7,
        [Description("Ваги")] scales = 8,
        [Description("Ваги-помішувачі")] mixing_scales = 9,
        [Description("Апарат високочастотний запаювання полімерних трубок")] sealer = 10,
        [Description("Апарат зварювання полімерних трубок")] welder = 11,
        [Description("Коагулометр")] coagulometer = 12,
        [Description("Кондиціонер")] conditioner = 13,
        [Description("Кулер для води")] cooler = 14,
        [Description("Мікроскоп")] microscope = 15,
        [Description("Морозильна камера")] freezers = 16,
        [Description("Плазмоекстрактор")] plasma_extractor = 17,
        [Description("Плита електрична")] plate_electric = 18,
        [Description("Плита газова")] plate_gas = 19,
        [Description("Промивач мікропланшетів")] microplate_washer = 20,
        [Description("Рефлактометр")] refractometer = 21,
        [Description("Рефлотрон")] reflotron = 22,
        [Description("Термопод")] thermal_sweat = 23,
        [Description("Термостат")] thermostat = 24,
        [Description("Установка для шокового заморожування плазми крові")] quick_freezer = 25,
        [Description("Фотометр")] photometer = 26,
        [Description("Холодильник")] refrigerator = 27,
        [Description("Центрифуга")] centrifuge = 28,
        [Description("Шафа медична холодильна")] refrigerator_сloset = 29,
        [Description("Шафа сушильна")] drying_сloset = 30,
        [Description("Шейкер")] shaker = 31,
        [Description("Аналізатор імуногематологічний")] immunohematological_analyzer = 32,
        [Description("Прилад для вимірювання радіації")] device_radiation = 34
    }
}
