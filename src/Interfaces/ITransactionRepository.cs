using Parpera.Models;

namespace Parpera.Interfaces;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetAll();
    Transaction? Get(int id);
}
