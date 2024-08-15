using System.Text.Json.Serialization;

namespace UnistreamTest2.Host.Dto;

public class EntityDto {
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("operationDate")]
    public required DateTime OperationDate { get; set; }

    [JsonPropertyName("amount")]
    public required decimal Amount { get; set; }
}