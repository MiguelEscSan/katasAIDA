namespace BankAccount;
 
public class Account : AccountService {
 
    // private List<Transaction> Transactions;
    // private DateProvider dateProvider;
    private TransactionService transactionService;

    private Printer printer;
    public Account(DateProvider dateProvider) {
        // this.Transactions = new List<Transaction>();
        // this.dateProvider = dateProvider;
        this.printer = new ConsolePrinter();
        this.transactionService = new TransactionService(dateProvider);
    }
 
    public void deposit(int amount) {
        // this.transactionService.AddTransaction(dateProvider.Date, amount);
        this.transactionService.Save(amount);
    }
 
    public void withdraw(int amount) {
        // this.transactionService.AddTransaction(dateProvider.Date, -amount);
        this.transactionService.Save(-amount);
    }
 
    public void printStatement() {
    
        List<(Transaction,int)> StatementInformation = GetPrintStatementInformation();
        this.printer.Print(StatementInformation);
    }
 
    private List<(Transaction,int)> GetPrintStatementInformation() {
        var SortedTransactions = this.transactionService.orderByDateTime();
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
}