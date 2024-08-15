using UnistreamTest2.Application.Models;

namespace UnistreamTest2.Application.Services;

public interface IEntityService {
    Task AddAsync(Guid id, DateTime operationDate, decimal amount);
    Task<Entity> GetAsync(Guid id);
}