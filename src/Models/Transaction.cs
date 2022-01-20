using System.ComponentModel.DataAnnotations;

namespace Parpera.Models;

public class Transaction
{
    public enum TransactionStatus
    {
        Cancelled,
        Completed,
        Pending
    }

    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public TransactionStatus Status { get; set; }
}
