namespace BankAccount;
 
public class Account : AccountService {
 
    private List<Transaction> Transactions;
    private DateProvider dateProvider;
 
    public Account(DateProvider dateProvider) {
        Transactions = new List<Transaction>();
        this.dateProvider = dateProvider;
    }
 
    public void deposit(int amount) {
        Transactions.Add(new Transaction(dateProvider.Date, amount));
    }
 
    public void withdraw(int amount) {
        Transactions.Add(new Transaction(dateProvider.Date, -amount));
    }
 
    public void printStatement() {
        
        List<(Transaction,int)> StatementInformation =GetPrintStatementInformation();

        System.Console.WriteLine("Date || Amount || Balance");
        for(int transaction = StatementInformation.Count - 1; transaction >= 0; transaction--) {
            System.Console.WriteLine($"{StatementInformation[transaction].Item1.ToString()} || {StatementInformation[transaction].Item2}");
        }
    }
 
    private List<(Transaction,int)> GetPrintStatementInformation() {
        
        var SortedTransactions = orderByDateTime();

        List<(Transaction,int)> StatementInformation = new List<(Transaction,int)>();
        int CurrentBalance= 0;
        foreach (Transaction transaction in SortedTransactions) {
            CurrentBalance += transaction.Amount;
            StatementInformation.Add((transaction, CurrentBalance));
        }
        return StatementInformation;
    }

    private List<Transaction> orderByDateTime() {
        var SortedTransactions = new List<Transaction>(Transactions);
        SortedTransactions.Sort((x, y) => x.Date.CompareTo(y.Date));
        return SortedTransactions;
    }
}