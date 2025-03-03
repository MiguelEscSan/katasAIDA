namespace BankAccountOutsideIn;

public class Transaction {

    public DateTime Date { get; }
    public int Amount { get; }

    public Transaction(DateTime Date, int Amount) {
        this.Date = Date;
        this.Amount = Amount;
    }

    public bool Equals(Transaction other) {
        return this.Date == other.Date && this.Amount == other.Amount;
    }
}