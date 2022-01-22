using Microsoft.EntityFrameworkCore;
using Parpera.Data;
using Parpera.Models;
using Parpera.Interfaces;

public class TransactionRepository : ITransactionRepository
{
    private readonly TransactionContext _context;

    public TransactionRepository(TransactionContext context)
    {
        _context = context;
    }

    public IEnumerable<Transaction> GetAll()
    {
        return _context.Transactions.AsNoTracking().ToList();
    }

    public Transaction? Get(int id)
    {
        return _context.Transactions.Find(id);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
