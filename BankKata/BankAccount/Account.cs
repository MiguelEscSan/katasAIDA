namespace BankAccount;
 
public class Account : AccountService {
 
    // private List<Transaction> Transactions;
    private TransactionService transactionService;
    private DateProvider dateProvider;
    private Printer printer;
    public Account(DateProvider dateProvider) {
        // this.Transactions = new List<Transaction>();
        this.transactionService = new TransactionService();
        this.dateProvider = dateProvider;
        this.printer = new ConsolePrinter();
    }
 
    public void deposit(int amount) {
        this.transactionService.AddTransaction(dateProvider.Date, amount);
    }
 
    public void withdraw(int amount) {
        this.transactionService.AddTransaction(dateProvider.Date, -amount);
    }
 
    public void printStatement() {
    
        List<(Transaction,int)> StatementInformation = GetPrintStatementInformation();
        this.printer.Print(StatementInformation);
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
        var SortedTransactions = new List<Transaction>(this.transactionService.Transactions);
        SortedTransactions.Sort((x, y) => x.Date.CompareTo(y.Date));
        return SortedTransactions;
    }
}