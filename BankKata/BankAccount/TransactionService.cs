namespace BankAccount;

public class TransactionService {
    public List<Transaction> Transactions {get;}

    public TransactionService() {
        this.Transactions = new List<Transaction>();
    }

    public void AddTransaction(DateTime Date, int Amount) {
        Transactions.Add(new Transaction(Date, Amount));
    }

}