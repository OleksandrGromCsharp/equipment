using equipment.Entities.Interfaces;

namespace equipment.Services.ConnectionDataBase.Interface
{
    internal interface IConnectionDataBase<T> where T : IEntities
    {
        bool LoadingEntities(ref List<T> entities, ref string? exception);

        bool RefreshEntities(List<T> entities, ref string? exception);
    }
}
