using Microsoft.EntityFrameworkCore;
using Parpera.Data;
using Parpera.Models;

public class TransactionRepository
{
    private readonly TransactionContext _context;

    public TransactionRepository(TransactionContext context)
    {
        _context = context;
    }

    public IEnumerable<Transaction> GetAll()
    {
        return _context.Transactions.AsNoTracking().OrderByDescending(t => t.CreatedAt).ToList();
    }

    public Transaction? Get(int id)
    {
        return _context.Transactions.Find(id);
    }

    public void UpdateStatus(Transaction transaction, Transaction.TransactionStatus status)
    {
        transaction.Status = status;
        _context.SaveChanges();
    }
}
