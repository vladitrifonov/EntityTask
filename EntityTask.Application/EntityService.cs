using EntityTask.Application.Exceptions;
using EntityTask.Domain.Contracts;
using EntityTask.Domain.Dto;
using EntityTask.Domain.Entities;

namespace EntityTask.Application
{
    public class EntityService : IEntityService
    {
        private readonly IEntityStorage _entityStorage;
        public EntityService(IEntityStorage entityStorage)
        {
            _entityStorage = entityStorage;
        }
        public async Task AddEntity(EntityDto entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            ThrowIfPropertyNull(new List<string> {entity.id.ToString(), entity.operationDate.ToString(), entity.amount.ToString() });

            await _entityStorage.AddEntity(new Entity {Id = entity.id, OperationDate = entity.operationDate, Amount = entity.amount });
        }

        public async Task<Entity?> GetEntity(Guid id)
        {
            var entity = await _entityStorage.GetEntity(id);

            if(entity == null)
            {
                throw new EntityNotFoundException($"There is no Entity with this Id: {id}");
            }

            return entity;
        }

        //can be extracted to dependency
        private void ThrowIfPropertyNull(IEnumerable<string> properties)
        {
            foreach (var item in properties)
            {
                if (string.IsNullOrEmpty(item))
                {
                    throw new ArgumentException($"Field {item} was null or emtpty");
                }
            }
        }
    }
}