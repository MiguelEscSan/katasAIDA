
namespace BankAccountOutsideIn;

public class InMemoryTransactionRepository : TransactionRepository
{

    internal List<Transaction> Transactions;

    public InMemoryTransactionRepository() {
        this.Transactions = new List<Transaction>();
    }

    public void Save(Transaction transaction) {
        Transactions.Add(transaction);
    }

    public List<Transaction> GetAllTransactions()
    {
        return Transactions;
    }

    public List<Transaction> orderByDateTime()
    {
        var SortedTransactions = new List<Transaction>(this.Transactions);
        SortedTransactions.Sort((x, y) => x.Date.CompareTo(y.Date));
        return SortedTransactions;
    }
}