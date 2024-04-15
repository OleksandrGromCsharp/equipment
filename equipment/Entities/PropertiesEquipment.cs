using equipment.Entities.Interfaces;
using equipment.ViewModels.Base;

namespace equipment.Entities
{
    internal class PropertiesEquipment : ViewModelBase, IEntities
    {
        private int _id;
        /// <summary>
        /// Унікальний ідентифікаційний номер
        /// </summary>
        public int Id { get => _id; set => Set(ref _id, value); }

        private string _name;
        /// <summary>
        /// Найменування характеристики
        /// </summary>
        public string Name { get => _name; set => Set(ref _name, value); }

        private UnitMeasurementEntity _unitMeasurement;
        /// <summary>
        /// Одиниці вимірювання
        /// </summary>
        public UnitMeasurementEntity UnitMeasurement { get => _unitMeasurement; set => Set(ref _unitMeasurement, value); }

        private double _passportValue;
        /// <summary>
        /// Паспортні дані
        /// </summary>
        public double PassportValue { get => _passportValue; set => Set(ref _passportValue, value); }

        private List<MeasuredData> _measurements;
        /// <summary>
        /// Список виміряних значень
        /// </summary>
        public List<MeasuredData> Measurements { get => _measurements; set => Set(ref _measurements, value); }
    }
}
