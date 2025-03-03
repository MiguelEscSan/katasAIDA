namespace BankAccountOutsideIn;

public class StatementRow {

    public Transaction transaction { get; }
    public int CurrentBalance { get;}
    public StatementRow(Transaction transaction, int CurrentBalance) {
        this.transaction = transaction;
        this.CurrentBalance = CurrentBalance;
    }

    public bool Equals(StatementRow other) {
        return transaction.Equals(other.transaction) && CurrentBalance == other.CurrentBalance;
    }
}