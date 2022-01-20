namespace Parpera.Models;

public class Transaction
{
    public enum TransactionStatus
    {
        Completed,
        Pending
    }

    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public TransactionStatus Status { get; set; }
}
