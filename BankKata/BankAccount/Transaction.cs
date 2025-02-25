namespace BankAccount;

public class Transaction {

    DateTime Date { get; }
    int Amount { get; }

    public Transaction(int Amount) {
        this.Date = DateTime.Now;
        this.Amount = Amount;
    }
}