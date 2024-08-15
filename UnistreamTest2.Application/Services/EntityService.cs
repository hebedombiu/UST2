using UnistreamTest2.Application.Exceptions;
using UnistreamTest2.Application.Extensions;
using UnistreamTest2.Application.Models;
using UnistreamTest2.Dal.Exceptions;
using UnistreamTest2.Dal.Repositories;

namespace UnistreamTest2.Application.Services;

public class EntityService : IEntityService {
    private readonly IRepository _repository;

    public EntityService(
        IRepository repository
    ) {
        _repository = repository;
    }

    public async Task AddAsync(Guid id, DateTime operationDate, decimal amount) {
        try {
            await _repository.AddAsync(id, operationDate, amount);
        } catch (DboConflictException) {
            throw new ConflictException();
        }
    }

    public async Task<Entity> GetAsync(Guid id) {
        var dbo = await _repository.GetOrDefaultAsync(id);
        if (dbo is null) {
            throw new NotFoundException();
        }

        return dbo.Map2Entity();
    }
}