using UnistreamTest2.Application.Models;
using UnistreamTest2.Dal.Entities;

namespace UnistreamTest2.Application.Extensions;

public static class EntityDboExtensions {
    public static Entity Map2Entity(this EntityDbo dbo) {
        return new Entity {
            Id = dbo.Id,
            OperationDate = dbo.OperationDate,
            Amount = dbo.Amount,
        };
    }
}