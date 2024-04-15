using equipment.Entities.Interfaces;
using equipment.ViewModels.Base;

namespace equipment.Entities
{
    internal class MeasuredData : ViewModelBase, IEntities
    {
        private int _id;
        /// <summary>
        /// Унікальний ідентифікаційний номер
        /// </summary>
        public int Id { get => _id; set => Set(ref _id, value); }

        private DateTime _date;
        /// <summary>
        /// Дата вимірювання
        /// </summary>
        public DateTime Date { get => _date; set => Set(ref _date, value); }

        private double _value;
        /// <summary>
        /// Виміряне значення
        /// </summary>
        public double Value { get => _value; set => Set(ref _value, value); }
    }
}
