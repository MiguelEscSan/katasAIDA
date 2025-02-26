namespace BankAccount;

public class Transaction {

    public DateTime Date { get; }
    public int Amount { get; }

    public Transaction(DateTime Date, int Amount) {
        this.Date = Date;
        this.Amount = Amount;
    }

    public override string ToString() {
        return $"{FormatDate()} || {this.Amount}";
    }

    public string FormatDate() {
        return this.Date.ToString("dd/MM/yyyy");
    }
}