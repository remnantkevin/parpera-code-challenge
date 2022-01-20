using Parpera.Data;
using Parpera.Models;
using Microsoft.AspNetCore.Mvc;

namespace Parpera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    TransactionRepository _repository;

    public TransactionController(TransactionRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<Transaction> GetAll()
    {
        return _repository.GetAll();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateStatus(int id, Transaction.TransactionStatus status)
    {
        var transaction = _repository.Get(id);

        if (transaction is not null)
        {
            _repository.UpdateStatus(transaction, status);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
