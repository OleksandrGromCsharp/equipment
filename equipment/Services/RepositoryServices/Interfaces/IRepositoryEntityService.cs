using equipment.Entities.Interfaces;

namespace equipment.Services.RepositoryServices.Interfaces
{
    internal interface IRepositoryEntityService<T> where T : IEntities
    {
        IEnumerable<T> GetAll();

        T? Get(int id) => GetAll().FirstOrDefault(entity => entity.Id == id);

        void Add(T entity);

        bool Remove(int id);

        void Update(int id, T entity);
    }
}
