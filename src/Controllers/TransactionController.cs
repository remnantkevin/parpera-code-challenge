using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parpera.Models;
using Parpera.Interfaces;

namespace Parpera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepository _repository;

    public TransactionController(ITransactionRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<Transaction> GetAll()
    {
        return _repository.GetAll().OrderByDescending(t => t.CreatedAt);
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] JsonPatchDocument<Transaction> patchDocument)
    {
        if (patchDocument is null)
            return BadRequest(ModelState);

        var transaction = _repository.Get(id);

        if (transaction is null)
            return NotFound();

        patchDocument.ApplyTo(transaction, ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return new ObjectResult(transaction);
    }
}
