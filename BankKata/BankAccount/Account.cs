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
        List<StatementRow> StatementInformation = GetPrintStatementInformation();
        this.printer.Print(StatementInformation);
    }

    private List<StatementRow> GetPrintStatementInformation() {
        var SortedTransactions = this.transactionRepository.orderByDateTime();
        return GetTransactionsWithBalances(SortedTransactions);
    }

    private List<StatementRow> GetTransactionsWithBalances( List<Transaction> SortedTransactions){
        List<StatementRow> StatementInformation = new List<StatementRow>();
        int CurrentBalance= 0;
        foreach (Transaction transaction in SortedTransactions) {
            CurrentBalance += transaction.Amount;
            StatementInformation.Add(new StatementRow(transaction, CurrentBalance));
        }
        return StatementInformation;
    }

}