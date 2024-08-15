using UnistreamTest2.Dal.Entities;

namespace UnistreamTest2.Dal.Repositories;

public interface IRepository {
    public Task AddAsync(Guid id, DateTime operationDate, decimal amount);
    public Task<EntityDbo?> GetOrDefaultAsync(Guid id);
}