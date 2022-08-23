using EntityTask.Domain.Entities;

namespace EntityTask.Domain.Contracts
{
    public interface IEntityStorage
    {
        Task AddEntity(Entity entity);
        Task<Entity?> GetEntity(Guid id);
    }
}
