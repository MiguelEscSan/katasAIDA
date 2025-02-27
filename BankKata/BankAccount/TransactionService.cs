namespace BankAccount;

public class TransactionService {
    public List<Transaction> Transactions {get;}
    private DateProvider dateProvider;

    public TransactionService(DateProvider dateProvider) {
        this.Transactions = new List<Transaction>();
        this.dateProvider = dateProvider;
    }

    public void Save(int Amount) {
        Transactions.Add(new Transaction(this.dateProvider.Date, Amount));
    }

    public List<Transaction> orderByDateTime() {
        var SortedTransactions = new List<Transaction>(this.Transactions);
        SortedTransactions.Sort((x, y) => x.Date.CompareTo(y.Date));
        return SortedTransactions;
    }

}