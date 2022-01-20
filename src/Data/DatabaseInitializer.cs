using Microsoft.EntityFrameworkCore;
using Parpera.Models;

namespace Parpera.Data;

public static class DatabaseInitializer
{
    public static void Initialize(TransactionContext context)
    {
        if (context.Transactions.Any())
        {
            // Database has already been seeded.
            return;
        }

        context.AddRange(
            new Transaction[]
            {
                new Transaction
                {
                    Description = "Bank Deposit",
                    Amount = 500,
                    Status = Transaction.TransactionStatus.Completed,
                    CreatedAt = new DateTime(2020, 3, 30, 23, 53, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "Amazon Online",
                    Amount = -30,
                    Status = Transaction.TransactionStatus.Completed,
                    CreatedAt = new DateTime(2020, 4, 1, 12, 47, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "Refund",
                    Amount = 30,
                    Status = Transaction.TransactionStatus.Completed,
                    CreatedAt = new DateTime(2020, 4, 9, 16, 26, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "Country Railways",
                    Amount = -167.78m,
                    Status = Transaction.TransactionStatus.Completed,
                    CreatedAt = new DateTime(2020, 6, 15, 18, 17, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "Mini Mart",
                    Amount = -56.43m,
                    Status = Transaction.TransactionStatus.Completed,
                    CreatedAt = new DateTime(2020, 8, 16, 21, 6, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "Mini Mart",
                    Amount = -23.76m,
                    Status = Transaction.TransactionStatus.Completed,
                    CreatedAt = new DateTime(2020, 8, 23, 17, 39, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "Apple Store",
                    Amount = -2000,
                    Status = Transaction.TransactionStatus.Cancelled,
                    CreatedAt = new DateTime(2020, 9, 6, 7, 33, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "Google Subscription",
                    Amount = -15,
                    Status = Transaction.TransactionStatus.Completed,
                    CreatedAt = new DateTime(2020, 9, 6, 10, 32, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "ATM withdrawal",
                    Amount = -20,
                    Status = Transaction.TransactionStatus.Completed,
                    CreatedAt = new DateTime(2020, 9, 7, 21, 52, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "Transfer to James",
                    Amount = -20,
                    Status = Transaction.TransactionStatus.Pending,
                    CreatedAt = new DateTime(2020, 9, 8, 9, 2, 23, DateTimeKind.Utc)
                },
                new Transaction
                {
                    Description = "Bank Deposit",
                    Amount = 500,
                    Status = Transaction.TransactionStatus.Completed,
                    CreatedAt = new DateTime(2020, 9, 8, 16, 34, 23, DateTimeKind.Utc)
                }
            }
        );

        context.SaveChanges();
    }
}
