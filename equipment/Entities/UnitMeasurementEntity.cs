using equipment.Entities.Interfaces;
using equipment.ViewModels.Base;

namespace equipment.Entities
{
    internal class UnitMeasurementEntity : ViewModelBase, IEntities
    {
        private int _id;
        /// <summary>
        /// Унікальний ідентифікаційний номер
        /// </summary>
        public int Id { get => _id; set => Set(ref _id, value); }

        private string _name;
        /// <summary>
        /// Найменування одиниці вимірювання згідно ДК 011-96
        /// </summary>
        public string Name { get => _name; set => Set(ref _name, value); }

        private int _code;
        /// <summary>
        /// Код одиниці вимірювання згідно ДК 011-96
        /// </summary>
        public int Code { get => _code; set => Set(ref _code, value); }

        private string _marking;
        /// <summary>
        /// Позначення (скорочення) одиниці вимірювання згідно ДК 011-96
        /// </summary>
        public string Marking { get => _marking; set => Set(ref _marking, value); }

        private string _groupName;
        /// <summary>
        /// Найменування групи одиниць вимірювання згідно ДК 011-96
        /// </summary>
        public string GroupName { get => _groupName; set => Set(ref _groupName, value); }
    }
}
