using Microsoft.EntityFrameworkCore;
using Parpera.Models;

namespace Parpera.Data;

public class TransactionContext : DbContext
{
    public TransactionContext(DbContextOptions<TransactionContext> options) : base(options) { }

    public DbSet<Transaction> Transactions => Set<Transaction>();
}
