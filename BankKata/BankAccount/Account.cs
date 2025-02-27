namespace BankAccount;
 
public class Account : AccountService {
 
    private DateProvider dateProvider;
    private TransactionRepository transactionRepository;

    private Printer printer;
    public Account(DateProvider dateProvider, Printer printer, TransactionRepository transactionRepository) {
        this.dateProvider = dateProvider;
        this.printer = printer;
        this.transactionRepository = transactionRepository;
    }
 
    public void deposit(int amount) {
        this.transactionRepository.Save(new Transaction(dateProvider.Date, amount));
    }
 
    public void withdraw(int amount) {
        this.transactionRepository.Save(new Transaction(dateProvider.Date, -amount));
    }
 
    public void printStatement() {
    
        List<(Transaction,int)> StatementInformation = GetPrintStatementInformation();
        this.printer.Print(StatementInformation);
    }
 
    private List<(Transaction,int)> GetPrintStatementInformation() {
        var SortedTransactions = this.transactionRepository.orderByDateTime();
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