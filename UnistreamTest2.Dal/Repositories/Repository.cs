using UnistreamTest2.Dal.Entities;
using UnistreamTest2.Dal.Services;

namespace UnistreamTest2.Dal.Repositories;

public class Repository : IRepository {
    private readonly IDb _db;

    public Repository(
        IDb db
    ) {
        _db = db;
    }

    public async Task AddAsync(Guid id, DateTime operationDate, decimal amount) {
        var entity = new EntityDbo {
            Id = id,
            OperationDate = operationDate,
            Amount = amount,
        };

        await _db.AddAsync(entity);
    }

    public async Task<EntityDbo?> GetOrDefaultAsync(Guid id) {
        return await _db.GetOrDefaultAsync(id);
    }
}