namespace UnistreamTest2.Application.Models;

public class Entity {
    public required Guid Id { get; set; }
    public required DateTime OperationDate { get; set; }
    public required decimal Amount { get; set; }
}