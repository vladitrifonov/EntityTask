using EntityTask.Domain.Contracts;
using EntityTask.Domain.Dto;
using EntityTask.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IEntityService _entityService;
        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet(Name = "Get")]
        public async Task<Entity> Get(Guid id)
        {
            return await _entityService.GetEntity(id);
        }

        [HttpPost(Name = "Add")]
        public async Task Add(EntityDto dto)
        {
            await _entityService.AddEntity(dto);
        }
    }
}