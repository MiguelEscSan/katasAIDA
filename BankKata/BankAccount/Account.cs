namespace BankAccount;
 
public class Account : AccountService {
 
    private List<Transaction> Transactions;
    private DateProvider dateProvider;
    private Printer printer;
    public Account(DateProvider dateProvider) {
        this.Transactions = new List<Transaction>();
        this.dateProvider = dateProvider;
        this.printer = new ConsolePrinter();
    }
 
    public void deposit(int amount) {
        Transactions.Add(new Transaction(dateProvider.Date, amount));
    }
 
    public void withdraw(int amount) {
        Transactions.Add(new Transaction(dateProvider.Date, -amount));
    }
 
    public void printStatement() {
    
        List<(Transaction,int)> StatementInformation = GetPrintStatementInformation();
        this.printer.Print(StatementInformation);
    }
 
    private List<(Transaction,int)> GetPrintStatementInformation() {
        
        var SortedTransactions = orderByDateTime();
        return GetTransactionsWithBalances(SortedTransactions);
    }

    private List<(Transaction,int)> GetTransactionsWithBalances( List<Transaction> SortedTransactions){

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