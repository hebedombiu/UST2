using UnistreamTest2.Dal.Entities;

namespace UnistreamTest2.Dal.Services;

public interface IDb {
    Task AddAsync(EntityDbo entity);
    Task<EntityDbo?> GetOrDefaultAsync(Guid id);
}