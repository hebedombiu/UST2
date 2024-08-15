using System.Collections.Concurrent;
using UnistreamTest2.Dal.Entities;
using UnistreamTest2.Dal.Exceptions;

namespace UnistreamTest2.Dal.Services;

public class MemoryDb : IDb {
    private readonly ConcurrentDictionary<Guid, EntityDbo> _cache = new();

    public Task AddAsync(EntityDbo entity) {
        if (!_cache.TryAdd(entity.Id, entity)) {
            throw new DboConflictException();
        }

        return Task.CompletedTask;
    }

    public Task<EntityDbo?> GetOrDefaultAsync(Guid id) {
        if (!_cache.TryGetValue(id, out var entity)) {
            return Task.FromResult<EntityDbo?>(default);
        }

        return Task.FromResult<EntityDbo?>(entity);
    }
}