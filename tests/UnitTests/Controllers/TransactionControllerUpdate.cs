using Microsoft.AspNetCore.JsonPatch;
using Moq;
using Xunit;
using FluentAssertions;
using FluentAssertions.AspNetCore.Mvc;
using Parpera.Controllers;
using Parpera.Interfaces;
using Parpera.Models;

namespace Tests.UnitTests.Controllers;

public class TransactionControllerUpdate
{
    Transaction existingTransaction;
    Mock<ITransactionRepository> repoMock;
    TransactionController controller;

    public TransactionControllerUpdate()
    {
        this.existingTransaction = GetTestTransaction();

        this.repoMock = new Mock<ITransactionRepository>();
        repoMock.Setup(repo => repo.Get(existingTransaction.Id)).Returns(existingTransaction);

        this.controller = new TransactionController(repoMock.Object);
    }

    [Fact]
    public void ReturnsTransactionWithUpdatedStatus()
    {
        // Build request
        var transactionId = existingTransaction.Id;
        var jsonPatchDocument = new JsonPatchDocument<Transaction>();
        jsonPatchDocument.Replace((t) => t.Status, Transaction.TransactionStatus.Cancelled);

        // Process request
        var result = controller.Update(transactionId, jsonPatchDocument);

        // Transform response and test that Status was updated correctly.
        var updatedTransaction = result.Should().BeObjectResult().ValueAs<Transaction>();
        updatedTransaction.Status.Should().HaveSameValueAs(Transaction.TransactionStatus.Cancelled);
    }

    [Fact]
    public void RespondsWithBadRequestWhenPatchDocumentIsNull()
    {
        // Build request
        var transactionId = existingTransaction.Id;

        // Force null argument to test that we get the correct response in this case.
        var result = controller.Update(transactionId, null!);

        // Test
        result.Should().BeBadRequestObjectResult();
    }

    [Fact]
    public void RespondsWithBadRequestWhenModelIsPutIntoInvalidState()
    {
        // Build request and error state
        var transactionId = existingTransaction.Id;

        var jsonPatchDocument = new JsonPatchDocument<Transaction>();
        jsonPatchDocument.Replace((t) => t.Status, Transaction.TransactionStatus.Cancelled);

        controller.ModelState.AddModelError("Status", "Invalid value");

        // Process request
        var result = controller.Update(transactionId, jsonPatchDocument);

        // Test
        result.Should().BeBadRequestObjectResult();
    }

    [Fact]
    public void RespondWithNotFoundWhenNoTransactionHasProvidedId()
    {
        // Build request, repo, and controller
        var transactionId = 1;
        var jsonPatchDocument = new JsonPatchDocument<Transaction>();
        jsonPatchDocument.Replace((t) => t.Status, Transaction.TransactionStatus.Cancelled);

        var repoMock = new Mock<ITransactionRepository>();
        repoMock.Setup(repo => repo.Get(transactionId)).Returns(value: null);

        var controller = new TransactionController(repoMock.Object);

        // Process request
        var result = controller.Update(transactionId, jsonPatchDocument);

        // Test
        result.Should().BeNotFoundResult();
    }

    // Helpers

    public Transaction GetTestTransaction()
    {
        return new Transaction
        {
            Id = 1,
            Amount = 100,
            CreatedAt = new DateTime(2021, 6, 15, 18, 17, 23, DateTimeKind.Utc),
            Description = "Refund",
            Status = Transaction.TransactionStatus.Completed
        };
    }
}
