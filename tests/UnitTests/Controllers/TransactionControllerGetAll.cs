using FluentAssertions;
using Moq;
using Xunit;
using Parpera.Controllers;
using Parpera.Interfaces;
using Parpera.Models;

namespace Tests.UnitTests.Controllers;

public class TransactionContollerGetAll
{
    List<Transaction> testTransactions;
    Mock<ITransactionRepository> repoMock;
    TransactionController controller;

    public TransactionContollerGetAll()
    {
        this.testTransactions = GetTestTransactions();

        this.repoMock = new Mock<ITransactionRepository>();
        repoMock.Setup(repo => repo.GetAll()).Returns(testTransactions);

        this.controller = new TransactionController(repoMock.Object);
    }

    [Fact]
    public void ReturnsAllTransactions()
    {
        var result = controller.GetAll();

        result.Should().HaveCount(testTransactions.Count);
    }

    [Fact]
    public void ReturnsAllTransactionsInReverseChronologicalOrder()
    {
        var result = controller.GetAll();

        var orderedTransactions = GetTestTransactions().OrderByDescending(t => t.CreatedAt);
        result.Should().BeEquivalentTo(orderedTransactions);
    }

    // Helpers

    public List<Transaction> GetTestTransactions()
    {
        return new List<Transaction>
        {
            new Transaction
            {
                Id = 1,
                Amount = 100,
                CreatedAt = new DateTime(2021, 6, 15, 18, 17, 23, DateTimeKind.Utc),
                Description = "Refund",
                Status = Transaction.TransactionStatus.Completed
            },
            new Transaction
            {
                Id = 2,
                Amount = -56.34m,
                CreatedAt = new DateTime(2020, 6, 15, 18, 17, 23, DateTimeKind.Utc),
                Description = "Coles",
                Status = Transaction.TransactionStatus.Pending
            }
        };
    }
}
