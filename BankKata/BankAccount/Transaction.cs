namespace BankAccount;

public class Transaction {

    DateTime Date { get; }
    public int Amount { get; }

    public Transaction(int Amount) {
        this.Date = DateTime.Now;
        this.Amount = Amount;
    }

    public override string ToString() {
        return $"{FormatDate()} || {this.Amount} ";
    }

    public string FormatDate() {
        return this.Date.ToString("dd/MM/yyyy");
    }
}