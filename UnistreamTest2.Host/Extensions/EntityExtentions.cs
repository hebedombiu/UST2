using UnistreamTest2.Application.Models;
using UnistreamTest2.Host.Dto;

namespace UnistreamTest2.Host.Extensions;

public static class EntityExtentions {
    public static EntityDto Map2Dto(this Entity entity) {
        return new EntityDto {
            Id = entity.Id,
            OperationDate = entity.OperationDate,
            Amount = entity.Amount,
        };
    }
}