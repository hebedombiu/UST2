using Microsoft.AspNetCore.Mvc;
using UnistreamTest2.Application.Services;
using UnistreamTest2.Host.Extensions;
using UnistreamTest2.Host.Dto;

namespace UnistreamTest2.Host.Controllers;

[ApiController]
[Route("api/entity")]
public class EntityController : ControllerBase {
    private readonly ILogger<EntityController> _logger;
    private readonly IEntityService _entityService;

    public EntityController(
        ILogger<EntityController> logger,
        IEntityService entityService
    ) {
        _logger = logger;
        _entityService = entityService;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task AddEntity([FromBody] EntityDto entity) {
        await _entityService.AddAsync(entity.Id, entity.OperationDate, entity.Amount);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<EntityDto> GetEntity(Guid id) {
        var entity = await _entityService.GetAsync(id);
        return entity.Map2Dto();
    }
}