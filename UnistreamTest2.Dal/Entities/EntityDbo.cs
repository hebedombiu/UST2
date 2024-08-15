namespace UnistreamTest2.Dal.Entities;

public class EntityDbo {
    public required Guid Id { get; set; }
    public required DateTime OperationDate { get; set; }
    public required decimal Amount { get; set; }
}