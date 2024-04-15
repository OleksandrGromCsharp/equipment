using System.ComponentModel;

namespace equipment.Entities
{
    enum EnumUnit
    {
        [Description("Господарський склад")] economic_warehouse = 0,
        [Description("Відділ економіки, фінансів, бухгалтерського обліку та звітності")] vefboz = 8,
        [Description("Господарсько-обслуговуючого відділ")] gov = 1,
        [Description("Відділ контролю та забезпечення якості")] vkzya = 2,
        [Description("Відділ з інфекційного контролю")] vik = 3,
        [Description("Відділ забезпечення донорськими кадрами")] vzdk = 4,
        [Description("Відділ заготівлі і обробки крові та її компонентів")] vzokk = 5,
        [Description("Відділ лабораторного тестування крові та її компонентів")] vltkk = 6,
        [Description("Відділ зберігання та реалізації компонентів крові (експедиція)")] vzrkk = 7,
    }
}
