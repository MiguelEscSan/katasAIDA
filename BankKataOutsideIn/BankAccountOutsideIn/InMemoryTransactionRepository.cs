
namespace BankAccountOutsideIn;

public class InMemoryTransactionRepository : TransactionRepository
{
    public List<Transaction> GetAllTransactions()
    {
        throw new NotImplementedException();
    }

    public List<Transaction> orderByDateTime()
    {
        throw new NotImplementedException();
    }

    public void Save(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}