using EntityTask.Domain.Contracts;
using EntityTask.Domain.Entities;

namespace EntityTask.Infrastructure
{
    public class EntityStorage : IEntityStorage
    {
        private readonly List<Entity?> _localStorage = new List<Entity?>();

        public Task AddEntity(Entity entity)
        {           
            _localStorage.Add(entity);

            return Task.CompletedTask;
        }

        public Task<Entity?> GetEntity(Guid id)
        {
            return Task.FromResult(_localStorage.FirstOrDefault(x => x.Id == id));
        }
    }
}
