using EntityTask.Domain.Dto;
using EntityTask.Domain.Entities;

namespace EntityTask.Domain.Contracts
{
    public interface IEntityService
    {
        Task AddEntity(EntityDto entity);
        Task<Entity?> GetEntity(Guid id);
    }
}
