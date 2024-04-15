using equipment.Entities.Interfaces;
using equipment.Services.ConnectionDataBase;
using equipment.Services.RepositoryServices.Interfaces;

namespace equipment.Services.RepositoryServices
{
    internal class RepositoryMemory<T> : IRepositoryEntityService<T> where T : IEntities
    {
        /// <summary>
        /// Список екземплярів сутностей <T>
        /// </summary>
        private readonly List<T> _entities = [];

        /// <summary>
        /// Текст помилок при роботі з базою даних
        /// </summary>
        internal string? exception;

        /// <summary>
        /// Підключення до бази даних
        /// </summary>
        private readonly ConnectionBaseJson<T> connection = new(typeof(T).Name);



        /// <summary>
        /// Створення репозиторію
        /// </summary>
        public RepositoryMemory()
        {
            var entities = new List<T>();
            if (connection.LoadingEntities(ref _entities, ref exception))
                foreach (var entity in entities)
                    AddRepository(entity);
            else if(exception is null)
                throw new Exception();
        }

        /// <summary>
        /// Створення репозиторію
        /// </summary>
        /// <param name="entities">Колекція екземплярів сутностей <T></param>
        public RepositoryMemory(IEnumerable<T> entities)
        {
            foreach (var item in entities)
                Add(item);
        }

        /// <summary>
        /// Додавання екземпляра сутності <T> до репозиторію
        /// </summary>
        /// <param name="entity">Екземпляр сутності <T></param>
        protected void AddRepository(T entity)
        {
            if (_entities.Contains(entity))
                return;

            if (entity.Id is 0)
                entity.Id = (_entities.Count == 0) ? 0 : _entities[^1].Id + 1;

            _entities.Add(entity);
        }

        /// <summary>
        /// Додавання екземпляра сутності <T>
        /// </summary>
        /// <param name="entity">Екземпляр сутності <T></param>
        public void Add(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.GetType() != typeof(T))
                throw new ArgumentException($"Entity is not {typeof(T)}");
            if (_entities.Contains(entity))
                return;

            AddRepository(entity);

            if (!connection.RefreshEntities(GetAll().ToList(), ref exception))
            {
                Remove(entity.Id);
                throw new Exception(exception);
            }
        }

        /// <summary>
        /// Повернення Колекцію екземплярів сутностей <T>
        /// </summary>
        /// <returns>Колекцію екземплярів сутностей <T></returns>
        public IEnumerable<T> GetAll() => _entities;

        /// <summary>
        /// Видалення екземпляра сутності <T>
        /// </summary>
        /// <param name="id">Унікальний номер екземпляра сутності <T>, з якої беруться дані</param>
        /// <returns>Видалення пройшло успішно (true) чи не успішно (false)</returns>
        public bool Remove(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var _entity = ((IRepositoryEntityService<T>)this).Get(id);
            _entities.Remove(_entity);

            if (!connection.RefreshEntities(GetAll().ToList(), ref exception))
                throw new Exception(exception);
            return true;
        }

        /// <summary>
        /// Оновлення даних сутності <T>
        /// </summary>
        /// <param name="id">Унікальний номер екземпляра сутності <T>, з якої беруться дані</param>
        /// <param name="entity">Екземпляр сутності <T>, що оновлюється</param>
        public void Update(int id, T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.GetType() != typeof(T))
                throw new ArgumentException($"Entity is not {typeof(T)}");
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            
            var _entity = ((IRepositoryEntityService<T>)this).Get(id);
            if (_entity is null)
                throw new ArgumentNullException(nameof(entity));

            _entity = entity;

            if (!connection.RefreshEntities(GetAll().ToList(), ref exception))
                throw new Exception(exception);
        }
    }
}
