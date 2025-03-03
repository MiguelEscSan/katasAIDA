
namespace BankAccountOutsideIn;

public class InMemoryTransactionRepository : TransactionRepository
{

    internal List<Transaction> Transactions{get;}

    public InMemoryTransactionRepository() {
        this.Transactions = new List<Transaction>();
    }

    public void Save(Transaction transaction) {
        Transactions.Add(transaction);
    }

    public List<Transaction> GetAllTransactions()
    {
        throw new NotImplementedException();
    }

    public List<Transaction> orderByDateTime()
    {
        throw new NotImplementedException();
    }
}